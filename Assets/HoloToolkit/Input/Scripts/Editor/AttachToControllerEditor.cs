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

using UnityEditor;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    [CustomEditor(typeof(AttachToController))]
    public class AttachToControllerEditor : ControllerFinderEditor
    {
        private SerializedProperty positionOffsetProperty;
        private SerializedProperty rotationOffsetProperty;
        private SerializedProperty scaleOffsetProperty;
        private SerializedProperty setScaleOnAttachProperty;
        private SerializedProperty setChildrenInactiveWhenDetachedProperty;

        protected override void OnEnable()
        {
            base.OnEnable();

            positionOffsetProperty = serializedObject.FindProperty("PositionOffset");
            rotationOffsetProperty = serializedObject.FindProperty("RotationOffset");
            scaleOffsetProperty = serializedObject.FindProperty("ScaleOffset");
            setScaleOnAttachProperty = serializedObject.FindProperty("SetScaleOnAttach");
            setChildrenInactiveWhenDetachedProperty = serializedObject.FindProperty("SetChildrenInactiveWhenDetached");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            serializedObject.Update();

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Attachment Options", new GUIStyle("Label") { fontStyle = FontStyle.Bold });
            EditorGUILayout.Space();
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(positionOffsetProperty);
            EditorGUILayout.PropertyField(rotationOffsetProperty);
            EditorGUILayout.PropertyField(scaleOffsetProperty);
            EditorGUILayout.PropertyField(setScaleOnAttachProperty);
            EditorGUILayout.PropertyField(setChildrenInactiveWhenDetachedProperty);

            EditorGUI.indentLevel--;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
