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
    /// A helper class for making applications more usable across different devices.
    /// </summary>
    public static class UsabilityUtilities
    {
        /// <summary>
        /// Gets a factor useful for scaling visual and interactable objects based on a camera's characteristics (resolution, field of view, etc).
        /// </summary>
        /// <param name="camera">The camera whose characteristics to consider.</param>
        /// <returns>The scale factor.</returns>
        public static float GetUsabilityScaleFactor(Camera camera)
        {
            float scaleFactor;

            if (camera == null)
            {
                Debug.LogError("camera is required.");
                scaleFactor = 1f;
            }
            else
            {
                const float HololensV1PixelHeight = 720f;
                const float HololensV1FieldOfView = 17.15f;
                const float HololensV1PixelsPerDegree = (HololensV1PixelHeight / HololensV1FieldOfView);

                float pixelsPerDegree = (camera.pixelHeight / camera.fieldOfView);

                // This scaling equation was derived by having a number of people look at a piece of UI with text
                // on a HoloLens V1 and a few other HMDs. Each person scaled the content up or down until they
                // reached an "optimal usability" scale for that HMD. Then, the chosen "optimal usability" scales
                // were plotted against the HMDs' pixels per degree, and an equation was chosen that approximated
                // the chosen scales across people and HMDs decently well.
                //
                // The equation currently places HoloLensV1 at 1x scale, which means content previously designed
                // for HoloLens will work as expected. Also, it's asymptotic, so HMDs with extremely high pixels
                // per degree won't shrink content down too quickly.
                //
                // All that said, keep in mind that as new HMDs are created with different pixels per degree and
                // different visual characteristics, the equation may need to be adjusted or reworked to include
                // those new characteristics as input to make sure it best targets the broad range of devices.

                float unclampedScaleFactor = Mathf.Sqrt(HololensV1PixelsPerDegree / pixelsPerDegree);

                const float MinimumScaleFactor = 0.1f;
                const float MaximumScaleFactor = 10f;

                scaleFactor = Mathf.Clamp(unclampedScaleFactor, MinimumScaleFactor, MaximumScaleFactor);

#if !UNITY_EDITOR
                Debug.AssertFormat(unclampedScaleFactor == scaleFactor,
                    "Usability scale factor got clamped from {0} to {1}. Are we calculating HMD characteristics correctly?",
                    unclampedScaleFactor,
                    scaleFactor
                    );
#endif
            }

            return scaleFactor;
        }
    }
}
