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
using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Extensions for the UnityEditor.EditorGUILayout class.
    /// </summary>
    public static class EditorGUILayoutExtensions
    {
        public static bool Button(string text, params GUILayoutOption[] options)
        {
            return Button(text, GUI.skin.button, options);
        }

        public static bool Button(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(EditorGUIExtensions.Indent);
            bool pressed = GUILayout.Button(text, style, options);
            EditorGUILayout.EndHorizontal();
            return pressed;
        }

        public static void Label(string text, params GUILayoutOption[] options)
        {
            Label(text, EditorStyles.label, options);
        }

        public static void Label(string text, GUIStyle style, params GUILayoutOption[] options)
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(EditorGUIExtensions.Indent);
            GUILayout.Label(text, style, options);
            EditorGUILayout.EndHorizontal();
        }

        public static T ObjectField<T>(GUIContent guiContent, T value, bool allowSceneObjects = false, GUILayoutOption[] guiLayoutOptions = null)
        {
            object objValue = value;

            if (objValue == null)
            {
                // We want to return null so we can display our blank field.
                return (T)objValue;
            }

            Type valueType = objValue.GetType();
            if (valueType == typeof(Material))
            {
                objValue = EditorGUILayout.ObjectField(guiContent, (Material)objValue, typeof(Material), allowSceneObjects, guiLayoutOptions);
            }
            else if (valueType == typeof(SceneAsset))
            {
                objValue = EditorGUILayout.ObjectField(guiContent, (SceneAsset)objValue, typeof(SceneAsset), allowSceneObjects, guiLayoutOptions);
            }
            else if (objValue is UnityEngine.Object)
            {
                objValue = EditorGUILayout.ObjectField(guiContent, (UnityEngine.Object)objValue, valueType, allowSceneObjects, guiLayoutOptions);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Unimplemented value type: {0}.",
                        valueType),
                    "value");
            }

            return (T)objValue;
        }
    }
}
