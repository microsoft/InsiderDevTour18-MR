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

#if UNITY_WSA
using UnityEngine;
#if !UNITY_2017_2_OR_NEWER
using UnityEngine.VR.WSA.Input;
#else
using UnityEngine.XR.WSA.Input;
#if !UNITY_EDITOR
using System;
using System.Collections.Generic;
using Windows.Devices.Haptics;
using Windows.Foundation;
using Windows.Perception;
using Windows.Storage.Streams;
using Windows.UI.Input.Spatial;
#elif UNITY_EDITOR_WIN
using System.Runtime.InteropServices;
#endif
#endif
#endif

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Extensions for the InteractionSource class to add haptics and expose the renderable model.
    /// </summary>
    public static class InteractionSourceExtensions
    {
#if UNITY_2017_2_OR_NEWER
#if UNITY_EDITOR_WIN && UNITY_WSA
        [DllImport("EditorMotionController")]
        private static extern bool StartHaptics([In] uint controllerId, [In] float intensity, [In] float durationInSeconds);

        [DllImport("EditorMotionController")]
        private static extern bool StopHaptics([In] uint controllerId);
#endif // UNITY_EDITOR_WIN && UNITY_WSA

        // This value is standardized according to www.usb.org/developers/hidpage/HUTRR63b_-_Haptics_Page_Redline.pdf
        private const ushort ContinuousBuzzWaveform = 0x1004;

#if UNITY_WSA
        public static void StartHaptics(this InteractionSource interactionSource, float intensity)
        {
            interactionSource.StartHaptics(intensity, float.MaxValue);
        }

        public static void StartHaptics(this InteractionSource interactionSource, float intensity, float durationInSeconds)
        {
            if (!WindowsApiChecker.UniversalApiContractV4_IsAvailable && !Application.isEditor)
            {
                return;
            }

#if !UNITY_EDITOR
            UnityEngine.WSA.Application.InvokeOnUIThread(() =>
            {
                IReadOnlyList<SpatialInteractionSourceState> sources = SpatialInteractionManager.GetForCurrentView().GetDetectedSourcesAtTimestamp(PerceptionTimestampHelper.FromHistoricalTargetTime(DateTimeOffset.Now));

                foreach (SpatialInteractionSourceState sourceState in sources)
                {
                    if (sourceState.Source.Id.Equals(interactionSource.id))
                    {
                        SimpleHapticsController simpleHapticsController = sourceState.Source.Controller.SimpleHapticsController;
                        foreach (SimpleHapticsControllerFeedback hapticsFeedback in simpleHapticsController.SupportedFeedback)
                        {
                            if (hapticsFeedback.Waveform.Equals(ContinuousBuzzWaveform))
                            {
                                if (durationInSeconds.Equals(float.MaxValue))
                                {
                                    simpleHapticsController.SendHapticFeedback(hapticsFeedback, intensity);
                                }
                                else
                                {
                                    simpleHapticsController.SendHapticFeedbackForDuration(hapticsFeedback, intensity, TimeSpan.FromSeconds(durationInSeconds));
                                }
                                return;
                            }
                        }
                    }
                }
            }, true);
#elif UNITY_EDITOR_WIN
            StartHaptics(interactionSource.id, intensity, durationInSeconds);
#endif // !UNITY_EDITOR
        }

        public static void StopHaptics(this InteractionSource interactionSource)
        {
            if (!WindowsApiChecker.UniversalApiContractV4_IsAvailable && !Application.isEditor)
            {
                return;
            }

#if !UNITY_EDITOR
            UnityEngine.WSA.Application.InvokeOnUIThread(() =>
            {
                IReadOnlyList<SpatialInteractionSourceState> sources = SpatialInteractionManager.GetForCurrentView().GetDetectedSourcesAtTimestamp(PerceptionTimestampHelper.FromHistoricalTargetTime(DateTimeOffset.Now));

                foreach (SpatialInteractionSourceState sourceState in sources)
                {
                    if (sourceState.Source.Id.Equals(interactionSource.id))
                    {
                        sourceState.Source.Controller.SimpleHapticsController.StopFeedback();
                    }
                }
            }, true);
#elif UNITY_EDITOR_WIN
            StopHaptics(interactionSource.id);
#endif // !UNITY_EDITOR
        }

#if !UNITY_EDITOR
        public static IAsyncOperation<IRandomAccessStreamWithContentType> TryGetRenderableModelAsync(this InteractionSource interactionSource)
        {
            IAsyncOperation<IRandomAccessStreamWithContentType> returnValue = null;

            if (WindowsApiChecker.UniversalApiContractV5_IsAvailable)
            {
                UnityEngine.WSA.Application.InvokeOnUIThread(() =>
                {
                    IReadOnlyList<SpatialInteractionSourceState> sources = SpatialInteractionManager.GetForCurrentView().GetDetectedSourcesAtTimestamp(PerceptionTimestampHelper.FromHistoricalTargetTime(DateTimeOffset.Now));

                    foreach (SpatialInteractionSourceState sourceState in sources)
                    {
                        if (sourceState.Source.Id.Equals(interactionSource.id))
                        {
                            returnValue = sourceState.Source.Controller.TryGetRenderableModelAsync();
                        }
                    }
                }, true);
            }

            return returnValue;
        }
#endif // !UNITY_EDITOR
#endif // UNITY_WSA
#endif // UNITY_2017_2_OR_NEWER
    }
}
