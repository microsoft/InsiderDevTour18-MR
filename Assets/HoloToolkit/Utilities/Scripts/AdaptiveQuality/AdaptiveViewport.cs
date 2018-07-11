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
using System;
using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Changes the VR viewport to correlate to the requested quality, trying to maintain a steady frame rate by reducing the amount of pixels rendered.
    /// Uses the AdaptiveQuality component to respond to quality change events.
    /// At MaxQualityLevel, the viewport will be set to 1.0 and will linearly drop of to MinViewportSize at MinQualityLevel
    /// Note, that it is ok to have the quality levels in this component correlate to a subset of the levels reported from the AdaptiveQuality component
    /// </summary>

    public class AdaptiveViewport : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The quality level where the viewport will be at full size.")]
        private int FullSizeQualityLevel = 5;

        [SerializeField]
        [Tooltip("The quality level where the viewport will be at Min Viewport Size.")]
        private int MinSizeQualityLevel = -5;

        [SerializeField]
        [Tooltip("Percentage size of viewport when quality is at Min Size Quality Level.")]
        private float MinViewportSize = 0.5f;

        [SerializeField]
        private AdaptiveQuality qualityController = null;

        public float CurrentScale { get; private set; }

        private void OnEnable()
        {
            CurrentScale = 1.0f;

            Debug.Assert(qualityController != null, "The AdpativeViewport needs a connection to a AdaptiveQuality component.");

            //Register our callback to the AdaptiveQuality component
            if (qualityController)
            {
                qualityController.QualityChanged += QualityChangedEvent;
                SetScaleFromQuality(qualityController.QualityLevel);
            }
        }

        private void OnDisable()
        {
            if (qualityController)
            {
                qualityController.QualityChanged -= QualityChangedEvent;
            }

#if UNITY_2017_2_OR_NEWER
            UnityEngine.XR.XRSettings.renderViewportScale = 1.0f;
#else
            UnityEngine.VR.VRSettings.renderViewportScale = 1.0f;
#endif
        }

        protected void OnPreCull()
        {
#if UNITY_2017_2_OR_NEWER
            UnityEngine.XR.XRSettings.renderViewportScale = CurrentScale;
#else
            UnityEngine.VR.VRSettings.renderViewportScale = CurrentScale;
#endif
        }

        private void QualityChangedEvent(int newQuality, int previousQuality)
        {
            SetScaleFromQuality(newQuality);
        }

        private void SetScaleFromQuality(int quality)
        {
            //Clamp the quality to our min and max
            int clampedQuality = Mathf.Clamp(quality, MinSizeQualityLevel, FullSizeQualityLevel);

            //Calculate our new scale value based on quality
            float lerpVal = Mathf.InverseLerp(MinSizeQualityLevel, FullSizeQualityLevel, clampedQuality);
            CurrentScale = Mathf.Lerp(MinViewportSize, 1.0f, lerpVal);
        }
    }
}
