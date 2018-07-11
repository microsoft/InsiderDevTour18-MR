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

namespace HoloToolkit.Unity.InputModule
{
    /// <summary>
    /// Data struct for cursor state information for the Animated Cursor, which leverages the Unity animation system..
    /// This defines a modification to an Unity animation parameter, based on cursor state.
    /// </summary>
    [Serializable]
    public struct AnimCursorDatum
    {
        public string Name;
        public CursorStateEnum CursorState;
        public AnimatorParameter Parameter;

        /// <summary>
        /// Types that an animation parameter can have in the Unity animation system.
        /// </summary>
        [Obsolete("Use Parameter")]
        public enum AnimInputTypeEnum
        {
            Int,
            Trigger,
            Bool,
            Float
        }

        [Obsolete("Use Parameter")]
        [Tooltip("Type of the animation parameter to modify.")]
        public AnimInputTypeEnum AnimInputType;

        [Obsolete("Use Parameter")]
        [Tooltip("Name of the animation parameter to modify.")]
        public string AnimParameterName;

        [Obsolete("Use Parameter")]
        [Tooltip("If the animation parameter type is a bool, value to set. Ignored otherwise.")]
        public bool AnimBoolValue;

        [Obsolete("Use Parameter")]
        [Tooltip("If the animation parameter type is an int, value to set. Ignored otherwise.")]
        public int AnimIntValue;

        [Obsolete("Use Parameter")]
        [Tooltip("If the animation parameter type is a float, value to set. Ignored otherwise.")]
        public float AnimFloatValue;
    }
}