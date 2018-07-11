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
    /// Provides interpolation over Color.
    /// </summary>
    [Serializable]
    public class InterpolatedColor : InterpolatedValue<Color>
    {
        /// <summary>
        /// Instantiates the InterpolatedColor with default of Color as initial value and skipping the first update frame.
        /// </summary>
        public InterpolatedColor() : this(default(Color)) { }

        /// <summary>
        /// Instantiates the InterpolatedColor with a given Color value as initial value and defaulted to skipping the first update frame.
        /// </summary>
        /// <param name="initialValue">Initial current value to use.</param>
        /// <param name="skipFirstUpdateFrame">A flag to skip first update frame after the interpolation target has been set.</param>
        public InterpolatedColor(Color initialValue, bool skipFirstUpdateFrame = false)
            : base(initialValue, skipFirstUpdateFrame)
        { }

        /// <summary>
        /// Overrides the method to calculate the current Color interpolation value by using a Color.Lerp function.
        /// </summary>
        /// <remarks>This method is public because of a Unity compilation bug when dealing with abstract methods on generics.</remarks>
        /// <param name="startValue">The Color value that the interpolation started at.</param>
        /// <param name="targetValue">The target Color value that the interpolation is moving to.</param>
        /// <param name="curveValue">A curve evaluated interpolation position value. This will be in range of [0, 1]</param>
        /// <returns>The new calculated Color interpolation value.</returns>
        public override Color ApplyCurveValue(Color startValue, Color targetValue, float curveValue)
        {
            return Color.Lerp(startValue, targetValue, curveValue);
        }

        /// <summary>
        /// Overrides the method to check if two Colors are equal.
        /// </summary>
        /// <remarks>This method is public because of a Unity compilation bug when dealing with abstract methods on generics.</remarks>
        /// <param name="one">First Color value.</param>
        /// <param name="other">Second Color value.</param>
        /// <returns>True if the Colors are equal.</returns>
        public override bool DoValuesEqual(Color one, Color other)
        {
            return one == other;
        }
    }
}