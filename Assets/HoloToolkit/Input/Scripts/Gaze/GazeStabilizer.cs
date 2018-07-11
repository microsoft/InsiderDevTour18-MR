// MIT License
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE

using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    /// <summary>
    /// GazeStabilizer iterates over samples of Raycast data and
    /// helps stabilize the user's gaze for precision targeting.
    /// </summary>
    public class GazeStabilizer : BaseRayStabilizer
    {
        [Tooltip("Number of samples that you want to iterate on.")]
        [Range(40, 120)]
        public int StoredStabilitySamples = 60;

        private Vector3 stablePosition;
        public override Vector3 StablePosition
        {
            get { return stablePosition; }
        }

        private Quaternion stableRotation;
        public override Quaternion StableRotation
        {
            get { return stableRotation; }
        }

        private Ray stableRay;
        public override Ray StableRay
        {
            get { return stableRay; }
        }

        /// <summary>
        /// Calculates standard deviation and averages for the gaze position.
        /// </summary>
        private readonly VectorRollingStatistics positionRollingStats = new VectorRollingStatistics();

        /// <summary>
        /// Calculates standard deviation and averages for the gaze direction.
        /// </summary>
        private readonly VectorRollingStatistics directionRollingStats = new VectorRollingStatistics();

        /// <summary>
        /// Tunable parameter.
        /// If the standard deviation for the position is above this value, we reset and stop stabilizing.
        /// </summary>
        private const float PositionStandardDeviationReset = 0.2f;

        /// <summary>
        /// Tunable parameter.
        /// If the standard deviation for the direction is above this value, we reset and stop stabilizing.
        /// </summary>
        private const float DirectionStandardDeviationReset = 0.1f;

        /// <summary>
        /// We must have at least this many samples with a standard deviation below the above constants to stabilize
        /// </summary>
        private const int MinimumSamplesRequiredToStabalize = 30;

        /// <summary>
        /// When not stabilizing this is the 'lerp' applied to the position and direction of the gaze to smooth it over time.
        /// </summary>
        private const float UnstabalizedLerpFactor = 0.3f;

        /// <summary>
        /// When stabilizing we will use the standard deviation of the position and direction to create the lerp value.
        /// By default this value will be low and the cursor will be too sluggish, so we 'boost' it by this value.
        /// </summary>
        private const float StabalizedLerpBoost = 10.0f;

        private void Awake()
        {
            directionRollingStats.Init(StoredStabilitySamples);
            positionRollingStats.Init(StoredStabilitySamples);
        }

        /// <summary>
        /// Updates the StablePosition and StableRotation based on GazeSample values.
        /// Call this method with RaycastHit parameters to get stable values.
        /// </summary>
        /// <param name="gazePosition">Position value from a RaycastHit point.</param>
        /// <param name="gazeDirection">Direction value from a RaycastHit rotation.</param>
        public override void UpdateStability(Vector3 gazePosition, Vector3 gazeDirection)
        {
            positionRollingStats.AddSample(gazePosition);
            directionRollingStats.AddSample(gazeDirection);

            float lerpPower = UnstabalizedLerpFactor;
            if (positionRollingStats.ActualSampleCount > MinimumSamplesRequiredToStabalize && // we have enough samples and...
                (positionRollingStats.CurrentStandardDeviation > PositionStandardDeviationReset || // the standard deviation of positions is high or...
                 directionRollingStats.CurrentStandardDeviation > DirectionStandardDeviationReset)) // the standard deviation of directions is high
            {
                // We've detected that the user's gaze is no longer fixed, so stop stabilizing so that gaze is responsive.
                //Debug.LogFormat("Reset {0} {1} {2} {3}", positionRollingStats.standardDeviation, positionRollingStats.standardDeviationsAway, directionRollignStats.standardDeviation, directionRollignStats.standardDeviationsAway);
                positionRollingStats.Reset();
                directionRollingStats.Reset();
            }
            else if (positionRollingStats.ActualSampleCount > MinimumSamplesRequiredToStabalize)
            {
                // We've detected that the user's gaze is fairly fixed, so start stabilizing.  The more fixed the gaze the less the cursor will move.
                lerpPower = StabalizedLerpBoost * (positionRollingStats.CurrentStandardDeviation + directionRollingStats.CurrentStandardDeviation);
            }

            stablePosition = Vector3.Lerp(stablePosition, gazePosition, lerpPower);
            stableRotation = Quaternion.LookRotation(Vector3.Lerp(stableRotation * Vector3.forward, gazeDirection, lerpPower));
            stableRay = new Ray(stablePosition, stableRotation * Vector3.forward);
        }
    }
}