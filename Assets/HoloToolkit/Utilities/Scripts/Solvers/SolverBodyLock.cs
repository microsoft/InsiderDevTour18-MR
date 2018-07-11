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

//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// SolverBodyLock provides a solver that follows the TrackedObject/TargetTransform. Adjusting "LerpTime"
    /// properties changes how quickly the object moves to the TracketObject/TargetTransform's position.
    /// </summary>
    public class SolverBodyLock : Solver
    {
        #region public enums
        public enum OrientationReference
        {
            /// <summary>
            /// Orient towards SolverHandler's tracked object or TargetTransform
            /// </summary>
            Default,
            /// <summary>
            /// Orient toward Camera.main instead of SolverHandler's properties.
            /// </summary>
            CameraFacing,
        }
        #endregion


        #region public members
        [Tooltip("The desired orientation of this object. Default sets the object to face the TrackedObject/TargetTransform. CameraFacing sets the object to always face the user.")]
        public OrientationReference Orientation = OrientationReference.Default;
        [Tooltip("XYZ offset for this object in relation to the TrackedObject/TargetTransform")]
        public Vector3 offset;
        [Tooltip("RotationTether snaps the object to be in front of TrackedObject regardless of the object's local rotation.")]
        public bool RotationTether = false;
        [Tooltip("TetherAngleSteps is the divison of steps this object can tether to. Higher the number, the more snapple steps.")]
        [Range(4, 12)]
        public int TetherAngleSteps = 6;
        #endregion

        public override void SolverUpdate()
        {
            Vector3 desiredPos = base.solverHandler.TransformTarget != null ? base.solverHandler.TransformTarget.position + offset : Vector3.zero;
            Quaternion desiredRot = Quaternion.identity;

            if (RotationTether)
            {
                float targetYRotation = GetOrientationRef().eulerAngles.y;
                float tetherYRotation = desiredRot.eulerAngles.y;
                float angleDiff = Mathf.DeltaAngle(targetYRotation, tetherYRotation);
                float tetherAngleLimit = 360f / TetherAngleSteps;

                if (Mathf.Abs(angleDiff) > tetherAngleLimit)
                {
                    int numSteps = Mathf.RoundToInt(targetYRotation / tetherAngleLimit);
                    tetherYRotation = numSteps * tetherAngleLimit;
                }

                desiredRot = Quaternion.Euler(0f, tetherYRotation, 0f);
            }

            desiredPos = solverHandler.TransformTarget.position + (desiredRot * offset);

            this.GoalPosition = desiredPos;
            this.GoalRotation = desiredRot;

            UpdateWorkingPosToGoal();
            UpdateWorkingRotToGoal();
        }

        private Transform GetOrientationRef()
        {
            if (Orientation == OrientationReference.CameraFacing)
            {
                return CameraCache.Main.transform;
            }
            return solverHandler.TransformTarget;
        }
    }
}