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
    public class EyeAdaptationModel : PostProcessingModel
    {
        public enum EyeAdaptationType
        {
            Progressive,
            Fixed
        }

        [Serializable]
        public struct Settings
        {
            [Range(1f, 99f), Tooltip("Filters the dark part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
            public float lowPercent;

            [Range(1f, 99f), Tooltip("Filters the bright part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
            public float highPercent;

            [Tooltip("Minimum average luminance to consider for auto exposure (in EV).")]
            public float minLuminance;

            [Tooltip("Maximum average luminance to consider for auto exposure (in EV).")]
            public float maxLuminance;

            [Min(0f), Tooltip("Exposure bias. Use this to offset the global exposure of the scene.")]
            public float keyValue;

            [Tooltip("Set this to true to let Unity handle the key value automatically based on average luminance.")]
            public bool dynamicKeyValue;

            [Tooltip("Use \"Progressive\" if you want the auto exposure to be animated. Use \"Fixed\" otherwise.")]
            public EyeAdaptationType adaptationType;

            [Min(0f), Tooltip("Adaptation speed from a dark to a light environment.")]
            public float speedUp;

            [Min(0f), Tooltip("Adaptation speed from a light to a dark environment.")]
            public float speedDown;

            [Range(-16, -1), Tooltip("Lower bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
            public int logMin;

            [Range(1, 16), Tooltip("Upper bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
            public int logMax;

            public static Settings defaultSettings
            {
                get
                {
                    return new Settings
                    {
                        lowPercent = 45f,
                        highPercent = 95f,

                        minLuminance = -5f,
                        maxLuminance = 1f,
                        keyValue = 0.25f,
                        dynamicKeyValue = true,

                        adaptationType = EyeAdaptationType.Progressive,
                        speedUp = 2f,
                        speedDown = 1f,

                        logMin = -8,
                        logMax = 4
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
