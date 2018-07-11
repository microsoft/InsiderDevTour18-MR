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

using System;
using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Class to encapsulate an interpolating Quaternion property.
    /// TODO: Remove if redundant to InterpolatedQuaternion.cs
    /// </summary>
    [Serializable]
    public class QuaternionInterpolated
    {
        /// <summary>
        /// Speed of change in magnitude.
        /// </summary>
        public float DeltaSpeed = 360f;

        /// <summary>
        /// Current value of the property.
        /// </summary>
        public Quaternion Value { get; private set; }
        /// <summary>
        /// Target value of the property.
        /// </summary>
        public Quaternion TargetValue { get; private set; }
        public Quaternion StartValue { get; private set; }
        public float Duration { get; private set; }
        public float Counter { get; private set; }

        public QuaternionInterpolated()
        {
            Reset(Quaternion.identity);
        }

        public QuaternionInterpolated(Quaternion initialValue)
        {
            Reset(initialValue);
        }

        /// <summary>
        /// Resets property to zero interpolation and set value.
        /// </summary>
        /// <param name="value">Desired value to reset</param>
        public void Reset(Quaternion value)
        {
            Value = value;
            TargetValue = value;
            StartValue = value;
            Duration = 0f;
            Counter = 0f;
        }

        /// <summary>
        /// Set a target for property to interpolate to.
        /// </summary>
        /// <param name="targetValue">Targeted value.</param>
        public void SetTarget(Quaternion targetValue)
        {
            TargetValue = targetValue;
            StartValue = Value;
            Duration = Quaternion.Angle(StartValue, TargetValue) / DeltaSpeed;
            Counter = 0f;
        }

        /// <summary>
        /// Returns whether there are further updates required to get the target value.
        /// </summary>
        /// <returns>True if updates are required. False otherwise.</returns>
        public bool HasUpdate()
        {
            return Quaternion.Angle(TargetValue, Value) > 0.05f;
        }

        /// <summary>
        /// Performs and fets the updated value.
        /// </summary>
        /// <param name="deltaTime">Tick delta.</param>
        /// <returns>Updated value.</returns>
        public Quaternion GetUpdate(float deltaTime)
        {
            Counter += deltaTime;
            Value = Quaternion.Slerp(StartValue, TargetValue, Counter / Duration);

            return Value;
        }
    }
}
