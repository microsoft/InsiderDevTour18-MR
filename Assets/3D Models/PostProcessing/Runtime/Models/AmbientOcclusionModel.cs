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

namespace UnityEngine.PostProcessing
{
    [Serializable]
    public class AmbientOcclusionModel : PostProcessingModel
    {
        public enum SampleCount
        {
            Lowest = 3,
            Low = 6,
            Medium = 10,
            High = 16
        }

        [Serializable]
        public struct Settings
        {
            [Range(0, 4), Tooltip("Degree of darkness produced by the effect.")]
            public float intensity;

            [Min(1e-4f), Tooltip("Radius of sample points, which affects extent of darkened areas.")]
            public float radius;

            [Tooltip("Number of sample points, which affects quality and performance.")]
            public SampleCount sampleCount;

            [Tooltip("Halves the resolution of the effect to increase performance at the cost of visual quality.")]
            public bool downsampling;

            [Tooltip("Forces compatibility with Forward rendered objects when working with the Deferred rendering path.")]
            public bool forceForwardCompatibility;

            [Tooltip("Enables the ambient-only mode in that the effect only affects ambient lighting. This mode is only available with the Deferred rendering path and HDR rendering.")]
            public bool ambientOnly;

            [Tooltip("Toggles the use of a higher precision depth texture with the forward rendering path (may impact performances). Has no effect with the deferred rendering path.")]
            public bool highPrecision;

            public static Settings defaultSettings
            {
                get
                {
                    return new Settings
                    {
                        intensity = 1f,
                        radius = 0.3f,
                        sampleCount = SampleCount.Medium,
                        downsampling = true,
                        forceForwardCompatibility = false,
                        ambientOnly = false,
                        highPrecision = false
                    };
                }
            }
        }

        [SerializeField]
        Settings m_Settings = Settings.defaultSettings;
        public Settings settings
        {
            get { return m_Settings; }
            set { m_Settings = value; }
        }

        public override void Reset()
        {
            m_Settings = Settings.defaultSettings;
        }
    }
}
