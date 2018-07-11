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
    /// Data class that carries the input data for the event handler.
    /// </summary>
    public struct XboxControllerData
    {
        public string GamePadName { get; set; }

        public float XboxLeftStickHorizontalAxis { get; set; }
        public float XboxLeftStickVerticalAxis { get; set; }
        public float XboxRightStickHorizontalAxis { get; set; }
        public float XboxRightStickVerticalAxis { get; set; }
        public float XboxDpadHorizontalAxis { get; set; }
        public float XboxDpadVerticalAxis { get; set; }
        public float XboxLeftTriggerAxis { get; set; }
        public float XboxRightTriggerAxis { get; set; }
        public float XboxSharedTriggerAxis { get; set; }

        public bool XboxA_Pressed { get; set; }
        public bool XboxB_Pressed { get; set; }
        public bool XboxX_Pressed { get; set; }
        public bool XboxY_Pressed { get; set; }
        public bool XboxLeftBumper_Pressed { get; set; }
        public bool XboxRightBumper_Pressed { get; set; }
        public bool XboxLeftStick_Pressed { get; set; }
        public bool XboxRightStick_Pressed { get; set; }
        public bool XboxView_Pressed { get; set; }
        public bool XboxMenu_Pressed { get; set; }

        public bool XboxA_Up { get; set; }
        public bool XboxB_Up { get; set; }
        public bool XboxX_Up { get; set; }
        public bool XboxY_Up { get; set; }
        public bool XboxLeftBumper_Up { get; set; }
        public bool XboxRightBumper_Up { get; set; }
        public bool XboxLeftStick_Up { get; set; }
        public bool XboxRightStick_Up { get; set; }
        public bool XboxView_Up { get; set; }
        public bool XboxMenu_Up { get; set; }

        public bool XboxA_Down { get; set; }
        public bool XboxB_Down { get; set; }
        public bool XboxX_Down { get; set; }
        public bool XboxY_Down { get; set; }
        public bool XboxLeftBumper_Down { get; set; }
        public bool XboxRightBumper_Down { get; set; }
        public bool XboxLeftStick_Down { get; set; }
        public bool XboxRightStick_Down { get; set; }
        public bool XboxView_Down { get; set; }
        public bool XboxMenu_Down { get; set; }
    }
}