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
    [CustomEditor(typeof(SpeechInputSource))]
    public class SpeechInputSourceEditor : Editor
    {
        private SerializedProperty persistentKeywordsProperty;
        private SerializedProperty recognizerStart;
        private SerializedProperty confidenceLevel;
        private SerializedProperty keywordsAndKeys;

        private void OnEnable()
        {
            persistentKeywordsProperty = serializedObject.FindProperty("PersistentKeywords");
            recognizerStart = serializedObject.FindProperty("RecognizerStart");
            confidenceLevel = serializedObject.FindProperty("recognitionConfidenceLevel");
            keywordsAndKeys = serializedObject.FindProperty("Keywords");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // Recognizer options
            EditorGUILayout.PropertyField(persistentKeywordsProperty);
            EditorGUILayout.PropertyField(recognizerStart);
            EditorGUILayout.PropertyField(confidenceLevel);
            
            // the Keywords field
            ShowList(keywordsAndKeys);
            serializedObject.ApplyModifiedProperties();

            // error and warning messages
            if (keywordsAndKeys.arraySize == 0)
            {
                EditorGUILayout.HelpBox("No keywords have been assigned!", MessageType.Warning);
            }
        }

        private static GUIContent removeButtonContent = new GUIContent("-", "Remove keyword");
        private static GUIContent addButtonContent = new GUIContent("+", "Add keyword");
        private static GUILayoutOption miniButtonWidth = GUILayout.Width(20.0f);

        private static void ShowList(SerializedProperty list)
        {
            // property name with expansion widget
            EditorGUILayout.PropertyField(list);

            if (list.isExpanded)
            {
                EditorGUI.indentLevel++;

                // header row
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Keyword");
                EditorGUILayout.LabelField("Key Shortcut");
                EditorGUILayout.EndHorizontal();

                // keyword rows
                for (int index = 0; index < list.arraySize; index++)
                {
                    EditorGUILayout.BeginHorizontal();
                    // the element
                    EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(index));
                    // the remove element button
                    if (GUILayout.Button(removeButtonContent, EditorStyles.miniButton, miniButtonWidth))
                    {
                        list.DeleteArrayElementAtIndex(index);
                    }
                    EditorGUILayout.EndHorizontal();
                }

                // add button row
                EditorGUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                // the add element button
                if (GUILayout.Button(addButtonContent, EditorStyles.miniButton, miniButtonWidth))
                {
                    list.InsertArrayElementAtIndex(list.arraySize);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUI.indentLevel--;
            }
        }
    }
}
