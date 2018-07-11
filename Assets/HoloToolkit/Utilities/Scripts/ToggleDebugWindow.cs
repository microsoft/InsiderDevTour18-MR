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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Toggles if the debug window is visible or not.
    /// </summary>
    public class ToggleDebugWindow : MonoBehaviour, IInputClickHandler
    {
        /// <summary>
        /// Current state of the debug window.
        /// </summary>
        private bool debugEnabled = false;

        /// <summary>
        /// The debug window.
        /// </summary>
        public GameObject DebugWindow;

        private void Start()
        {
            UpdateChildren();
        }

        /// <summary>
        /// When the user clicks this control, we toggle the state of the DebugWindow
        /// </summary>
        /// <param name="eventData"></param>
        public void OnInputClicked(InputClickedEventData eventData)
        {
            debugEnabled = !debugEnabled;
            UpdateChildren();
            eventData.Use();
        }

        /// <summary>
        /// Sets the debugwindow's active flag to debugEnabled.
        /// </summary>
        private void UpdateChildren()
        {
            DebugWindow.SetActive(debugEnabled);
        }
    }
}