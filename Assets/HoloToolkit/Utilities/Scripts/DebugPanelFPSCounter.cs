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
    /// Adds an FPS counter to the debug panel.
    /// </summary>
    public class DebugPanelFPSCounter : MonoBehaviour
    {
        /// <summary>
        /// Variables for an FPS counter
        /// </summary>
        private int frameCount;
        private int framesPerSecond;
        private int lastWholeTime;

        private void Start()
        {
            if (DebugPanel.Instance != null)
            {
                DebugPanel.Instance.RegisterExternalLogCallback(GetFps);
            }
        }

        private string GetFps()
        {
            // calculate the fps first 
            // (Note that we might want to do this in our update loop)
            UpdateFps();
            return string.Format("FPS: {0}\n", framesPerSecond);
        }

        /// <summary>
        /// Keeps track of rough frames per second.
        /// </summary>
        private void UpdateFps()
        {
            frameCount++;
            int currentWholeTime = (int) Time.realtimeSinceStartup;
            if (currentWholeTime != lastWholeTime)
            {
                lastWholeTime = currentWholeTime;
                framesPerSecond = frameCount;
                frameCount = 0;
            }
        }
    }
}