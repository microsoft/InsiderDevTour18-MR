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

using HoloToolkit.Unity;
using UnityEngine;

namespace HoloToolkit.Unity.Buttons
{
    public class ButtonSoundProfile : ButtonProfile
    {
        // Direct interaction clips
        [HideInMRTKInspector]
        public AudioClip ButtonCanceled;
        [HideInMRTKInspector]
        public AudioClip ButtonHeld;
        [HideInMRTKInspector]
        public AudioClip ButtonPressed;
        [HideInMRTKInspector]
        public AudioClip ButtonReleased;

        // State change clips
        [HideInMRTKInspector]
        public AudioClip ButtonObservation;
        [HideInMRTKInspector]
        public AudioClip ButtonObservationTargeted;
        [HideInMRTKInspector]
        public AudioClip ButtonTargeted;

        // Volumes
        [HideInMRTKInspector]
        public float ButtonCanceledVolume = 1f;
        [HideInMRTKInspector]
        public float ButtonHeldVolume = 1f;
        [HideInMRTKInspector]
        public float ButtonPressedVolume = 1f;
        [HideInMRTKInspector]
        public float ButtonReleasedVolume = 1f;
        [HideInMRTKInspector]
        public float ButtonObservationVolume = 1f;
        [HideInMRTKInspector]
        public float ButtonObservationTargetedVolume = 1f;
        [HideInMRTKInspector]
        public float ButtonTargetedVolume = 1f;

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(ButtonSoundProfile))]
        public class CustomEditor : ProfileInspector
        {
            protected override void DrawCustomFooter() {
                ButtonSoundProfile soundProfile = (ButtonSoundProfile)target;

                DrawClipEditor(ref soundProfile.ButtonPressed, ref soundProfile.ButtonPressedVolume, "Button Pressed");
                DrawClipEditor(ref soundProfile.ButtonTargeted, ref soundProfile.ButtonTargetedVolume, "Button Targeted");
                DrawClipEditor(ref soundProfile.ButtonHeld, ref soundProfile.ButtonHeldVolume, "Button Held");
                DrawClipEditor(ref soundProfile.ButtonReleased, ref soundProfile.ButtonReleasedVolume, "Button Released");
                DrawClipEditor(ref soundProfile.ButtonCanceled, ref soundProfile.ButtonCanceledVolume, "Button Canceled");
                DrawClipEditor(ref soundProfile.ButtonObservation, ref soundProfile.ButtonObservationVolume, "Button Observation");
                DrawClipEditor(ref soundProfile.ButtonObservationTargeted, ref soundProfile.ButtonObservationTargetedVolume, "Button Observation Targeted");
            }

            protected void DrawClipEditor(ref AudioClip clip, ref float volume, string label) {
                UnityEditor.EditorGUILayout.Space();
                UnityEditor.EditorGUILayout.LabelField(label, UnityEditor.EditorStyles.boldLabel);
                UnityEditor.EditorGUI.indentLevel++;
                UnityEditor.EditorGUILayout.BeginHorizontal();
                clip = (AudioClip)UnityEditor.EditorGUILayout.ObjectField(clip, typeof(UnityEngine.AudioClip), true);
                volume = UnityEditor.EditorGUILayout.Slider(volume, 0f, 1f);
                UnityEditor.EditorGUILayout.EndHorizontal();
                UnityEditor.EditorGUI.indentLevel--;
            }
        }
#endif
    }
}