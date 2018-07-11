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
    public class BuiltinDebugViewsModel : PostProcessingModel
    {
        [Serializable]
        public struct DepthSettings
        {
            [Range(0f, 1f), Tooltip("Scales the camera far plane before displaying the depth map.")]
            public float scale;

            public static DepthSettings defaultSettings
            {
                get
                {
                    return new DepthSettings
                    {
                        scale = 1f
                    };
                }
            }
        }

        [Serializable]
        public struct MotionVectorsSettings
        {
            [Range(0f, 1f), Tooltip("Opacity of the source render.")]
            public float sourceOpacity;

            [Range(0f, 1f), Tooltip("Opacity of the per-pixel motion vector colors.")]
            public float motionImageOpacity;

            [Min(0f), Tooltip("Because motion vectors are mainly very small vectors, you can use this setting to make them more visible.")]
            public float motionImageAmplitude;

            [Range(0f, 1f), Tooltip("Opacity for the motion vector arrows.")]
            public float motionVectorsOpacity;

            [Range(8, 64), Tooltip("The arrow density on screen.")]
            public int motionVectorsResolution;

            [Min(0f), Tooltip("Tweaks the arrows length.")]
            public float motionVectorsAmplitude;

            public static MotionVectorsSettings defaultSettings
            {
                get
                {
                    return new MotionVectorsSettings
                    {
                        sourceOpacity = 1f,

                        motionImageOpacity = 0f,
                        motionImageAmplitude = 16f,

                        motionVectorsOpacity = 1f,
                        motionVectorsResolution = 24,
                        motionVectorsAmplitude = 64f
                    };
                }
            }
        }

        public enum Mode
        {
            None,

            Depth,
            Normals,
            MotionVectors,

            AmbientOcclusion,
            EyeAdaptation,
            FocusPlane,
            PreGradingLog,
            LogLut,
            UserLut
        }

        [Serializable]
        public struct Settings
        {
            public Mode mode;
            public DepthSettings depth;
            public MotionVectorsSettings motionVectors;

            public static Settings defaultSettings
            {
                get
                {
                    return new Settings
                    {
                        mode = Mode.None,
                        depth = DepthSettings.defaultSettings,
                        motionVectors = MotionVectorsSettings.defaultSettings
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

        public bool willInterrupt
        {
            get
            {
                return !IsModeActive(Mode.None)
                       && !IsModeActive(Mode.EyeAdaptation)
                       && !IsModeActive(Mode.PreGradingLog)
                       && !IsModeActive(Mode.LogLut)
                       && !IsModeActive(Mode.UserLut);
            }
        }

        public override void Reset()
        {
            settings = Settings.defaultSettings;
        }

        public bool IsModeActive(Mode mode)
        {
            return m_Settings.mode == mode;
        }
    }
}
