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
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Base class for profile inspectors
    /// Profiles are scriptable objects that contain shared information
    /// To ensure that developers understand that they're editing 'global' data, 
    /// this inspector automatically displays a CONSISTENT warning message and 'profile' color to the controls
    /// It also provides a 'target component' so inspectors can differentiate between local / global editing
    /// See compound button component inspectors for usage examples
    /// </summary>
    #if UNITY_EDITOR
    public abstract class ProfileInspector : MRTKEditor
    {
        public Component targetComponent;

        protected override bool DisplayHeader
        {
            get
            {
                return targetComponent == null;
            }
        }

        protected override void BeginInspectorStyle()
        {
            if (targetComponent == null)
            {
                GUI.color = profileColor;
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                GUI.color = Color.Lerp(profileColor, Color.red, 0.5f);
                EditorGUILayout.LabelField("(Warning: this section edits the button profile. These changes will affect all objects that use this profile.)", EditorStyles.wordWrappedMiniLabel);
                GUI.color = defaultColor;
            }
        }

        protected override void EndInspectorStyle()
        {
            if (targetComponent == null)
            {
                EditorGUILayout.EndVertical();
            }
        }
    }
    #endif
}