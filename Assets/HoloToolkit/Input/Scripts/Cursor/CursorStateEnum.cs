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

namespace HoloToolkit.Unity.InputModule
{
    /// <summary>
    /// Enum for current cursor state
    /// </summary>
    public enum CursorStateEnum
    {
        /// <summary>
        /// Useful for releasing external override.
        /// See <c>CursorStateEnum.Contextual</c>
        /// </summary>
        None = -1,
        /// <summary>
        /// Not IsHandVisible
        /// </summary>
        Observe,
        /// <summary>
        /// Not IsHandVisible AND not IsInputSourceDown AND TargetedObject exists
        /// </summary>
        ObserveHover,
        /// <summary>
        /// IsHandVisible AND not IsInputSourceDown AND TargetedObject is NULL
        /// </summary>
        Interact,
        /// <summary>
        /// IsHandVisible AND not IsInputSourceDown AND TargetedObject exists
        /// </summary>
        InteractHover,
        /// <summary>
        /// IsHandVisible AND IsInputSourceDown
        /// </summary>
        Select,
        /// <summary>
        /// Available for use by classes that extend Cursor.
        /// No logic for setting Release state exists in the base Cursor class.
        /// </summary>
        Release,
        /// <summary>
        /// Allows for external override
        /// </summary>
        Contextual
    }
}