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

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Class to encapsulate an interpolating Vector3 property.
    /// TODO: Remove if redundant to InterpolatedVector3.cs
    /// </summary>
    public class Vector3Interpolated
    {
        /// <summary>
        /// Half-life used to control how fast values are interpolated.
        /// </summary>
        public float HalfLife = 0.08f;

        /// <summary>
        /// Current value of the property.
        /// </summary>
        public Vector3 Value { get; private set; }
        /// <summary>
        /// Target value of the property.
        /// </summary>
        public Vector3 TargetValue { get; private set; }

        public Vector3Interpolated()
        {
            Reset(Vector3.zero);
        }

        public Vector3Interpolated(Vector3 initialValue)
        {
            Reset(initialValue);
        }

        /// <summary>
        /// Resets property to zero interpolation and set value.
        /// </summary>
        /// <param name="value">Desired value to reset</param>
        public void Reset(Vector3 value)
        {
            Value = value;
            TargetValue = value;
        }

        /// <summary>
        /// Set a target for property to interpolate to.
        /// </summary>
        /// <param name="targetValue">Targeted value.</param>
        public void SetTarget(Vector3 targetValue)
        {
            TargetValue = targetValue;
        }

        /// <summary>
        /// Returns whether there are further updates required to get the target value.
        /// </summary>
        /// <returns>True if updates are required. False otherwise.</returns>
        public bool HasUpdate()
        {
            return TargetValue != Value;
        }

        /// <summary>
        /// Performs and gets the updated value.
        /// </summary>
        /// <param name="deltaTime">Tick delta.</param>
        /// <returns>Updated value.</returns>
        public Vector3 GetUpdate(float deltaTime)
        {
            Vector3 distance = (TargetValue - Value);

            if (distance.sqrMagnitude <= Mathf.Epsilon)
            {
                // When close enough, jump to the target
                Value = TargetValue;
            }
            else
            {
                Value = InterpolationUtilities.ExpDecay(Value, TargetValue, HalfLife, deltaTime);
            }


            return Value;
        }
    }
}
