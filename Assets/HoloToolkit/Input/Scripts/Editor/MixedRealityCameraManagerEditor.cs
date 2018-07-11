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

using HoloToolkit.Unity.InputModule;
using UnityEditor;
using UnityEngine;

namespace HoloToolKit.Unity
{
    [CustomEditor(typeof(MixedRealityCameraManager))]
    public class MixedRealityCameraManagerEditor : Editor
    {
        private SerializedProperty opaqueNearClip;
        private SerializedProperty opaqueClearFlags;
        private SerializedProperty opaqueBackgroundColor;
        private SerializedProperty opaqueQualityLevel;

        private SerializedProperty transparentNearClip;
        private SerializedProperty transparentClearFlags;
        private SerializedProperty transparentBackgroundColor;
        private SerializedProperty holoLensQualityLevel;

        private GUIContent nearClipTitle;
        private GUIContent clearFlagsTitle;
        private GUIStyle headerStyle;

        private void OnEnable()
        {
            opaqueNearClip = serializedObject.FindProperty("NearClipPlane_OpaqueDisplay");
            opaqueClearFlags = serializedObject.FindProperty("CameraClearFlags_OpaqueDisplay");
            opaqueBackgroundColor = serializedObject.FindProperty("BackgroundColor_OpaqueDisplay");
            opaqueQualityLevel = serializedObject.FindProperty("OpaqueQualityLevel");

            transparentNearClip = serializedObject.FindProperty("NearClipPlane_TransparentDisplay");
            transparentClearFlags = serializedObject.FindProperty("CameraClearFlags_TransparentDisplay");
            transparentBackgroundColor = serializedObject.FindProperty("BackgroundColor_TransparentDisplay");
            holoLensQualityLevel = serializedObject.FindProperty("HoloLensQualityLevel");
        }

        public override void OnInspectorGUI()
        {
            nearClipTitle = new GUIContent("Near Clip");
            clearFlagsTitle = new GUIContent("Clear Flags");
            headerStyle = new GUIStyle("label") { richText = true };

            serializedObject.Update();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("<b>Opaque Display Settings:</b>", headerStyle);
            EditorGUILayout.PropertyField(opaqueNearClip, nearClipTitle);
            EditorGUILayout.PropertyField(opaqueClearFlags, clearFlagsTitle);
            if ((CameraClearFlags)opaqueClearFlags.intValue == CameraClearFlags.Color)
            {
                opaqueBackgroundColor.colorValue = EditorGUILayout.ColorField("Background Color", opaqueBackgroundColor.colorValue);
            }

            opaqueQualityLevel.intValue = EditorGUILayout.Popup("Quality Setting", opaqueQualityLevel.intValue, QualitySettings.names);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("<b>Transparent Display Settings:</b>", headerStyle);
            EditorGUILayout.PropertyField(transparentNearClip, nearClipTitle);
            EditorGUILayout.PropertyField(transparentClearFlags, clearFlagsTitle);
            if ((CameraClearFlags)transparentClearFlags.intValue == CameraClearFlags.Color)
            {
                transparentBackgroundColor.colorValue = EditorGUILayout.ColorField("Background Color", transparentBackgroundColor.colorValue);
            }

            holoLensQualityLevel.intValue = EditorGUILayout.Popup("Quality Setting", holoLensQualityLevel.intValue, QualitySettings.names);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
