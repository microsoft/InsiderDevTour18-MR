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
using UnityEditor;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    [CustomEditor(typeof(XboxControllerInputSource))]
    public class XboxControllerInputSourceEditor : Editor
    {
        private SerializedProperty horizontalAxisProperty;
        private SerializedProperty verticalAxisProperty;
        private SerializedProperty submitButtonProperty;
        private SerializedProperty cancelButtonProperty;
        private SerializedProperty customMappingsProperty;

        private static bool useCustomMapping;

        private void OnEnable()
        {
            horizontalAxisProperty = serializedObject.FindProperty("horizontalAxis");
            verticalAxisProperty = serializedObject.FindProperty("verticalAxis");
            submitButtonProperty = serializedObject.FindProperty("submitButton");
            cancelButtonProperty = serializedObject.FindProperty("cancelButton");
            customMappingsProperty = serializedObject.FindProperty("mapping");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Event System Overrides", new GUIStyle("Label") { fontStyle = FontStyle.Bold });

            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(horizontalAxisProperty);
            EditorGUILayout.PropertyField(verticalAxisProperty);
            EditorGUILayout.PropertyField(submitButtonProperty);
            EditorGUILayout.PropertyField(cancelButtonProperty);

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();

            EditorGUI.BeginChangeCheck();

            useCustomMapping = EditorGUILayout.Toggle("Use Custom Mapping", useCustomMapping);

            if (EditorGUI.EndChangeCheck())
            {
                customMappingsProperty.arraySize = Enum.GetNames(typeof(XboxControllerMappingTypes)).Length;

                for (int i = 0; i < customMappingsProperty.arraySize; i++)
                {
                    customMappingsProperty.GetArrayElementAtIndex(i).FindPropertyRelative("Type").enumValueIndex = i;
                    customMappingsProperty.GetArrayElementAtIndex(i).FindPropertyRelative("Value").stringValue = string.Empty;
                }
            }

            if (useCustomMapping)
            {
                ShowList(customMappingsProperty);
            }

            serializedObject.ApplyModifiedProperties();
        }

        private static void ShowList(SerializedProperty list)
        {
            EditorGUILayout.Space();

            list.isExpanded = true;
            EditorGUI.indentLevel++;

            for (int i = 0; i < list.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();
                list.GetArrayElementAtIndex(i).FindPropertyRelative("Type").enumValueIndex = i;
                EditorGUILayout.LabelField(((XboxControllerMappingTypes)i).ToString());
                list.GetArrayElementAtIndex(i).FindPropertyRelative("Value").stringValue =
                    EditorGUILayout.TextField(list.GetArrayElementAtIndex(i).FindPropertyRelative("Value").stringValue);
                EditorGUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel--;
        }
    }
}
