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

namespace HoloToolkit.Unity.InputModule
{
    /// <summary>
    /// Xbox Controller axis and button types.
    /// </summary>
    [Flags]
    public enum XboxControllerMappingTypes
    {
        None = 0,
        XboxLeftStickHorizontal = 1,
        XboxLeftStickVertical = 2,
        XboxRightStickHorizontal = 3,
        XboxRightStickVertical = 4,
        XboxDpadHorizontal = 5,
        XboxDpadVertical = 6,
        XboxLeftTrigger = 7,
        XboxRightTrigger = 8,
        XboxSharedTrigger = 9,
        XboxA = 10,
        XboxB = 11,
        XboxX = 12,
        XboxY = 13,
        XboxView = 14,
        XboxMenu = 15,
        XboxLeftBumper = 16,
        XboxRightBumper = 17,
        XboxLeftStickClick = 18,
        XboxRightStickClick = 19
    }
}