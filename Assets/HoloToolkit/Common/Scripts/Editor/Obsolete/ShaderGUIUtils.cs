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
using UnityEditor;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Helper class for custom shader editors
    /// </summary>
    public static class ShaderGUIUtils
    {
        public static readonly GUILayoutOption[] GUILayoutEmptyArray = new GUILayoutOption[0];

        public static int IndentAmount = 1;

        //re-implementation of MaterialEditor internal
        public static Rect GetControlRectForSingleLine()
        {
            return EditorGUILayout.GetControlRect(true, 18f, EditorStyles.layerMaskField, GUILayoutEmptyArray);
        }

        //re-implementation of EditorGUI internal
        public static void GetRectsForMiniThumbnailField(Rect position, out Rect thumbRect, out Rect labelRect)
        {
            thumbRect = EditorGUI.IndentedRect(position);
            thumbRect.y -= 1f;
            thumbRect.height = 18f;
            thumbRect.width = 32f;
            float num = thumbRect.x + 30f;
            labelRect = new Rect(num, position.y, thumbRect.x + EditorGUIUtility.labelWidth - num, position.height);
        }

        public static void BeginHeaderProperty(MaterialEditor matEditor, string headerText, MaterialProperty prop)
        {
            matEditor.ShaderProperty(prop, GUIContent.none);
            var rect = GUILayoutUtility.GetLastRect();
            EditorGUI.indentLevel += IndentAmount;
            EditorGUI.LabelField(rect, headerText, EditorStyles.boldLabel);
        }

        public static void BeginHeader(string headerText)
        {
            EditorGUILayout.LabelField(headerText, EditorStyles.boldLabel);
            EditorGUI.indentLevel += IndentAmount;
        }

        public static void EndHeader()
        {
            EditorGUI.indentLevel -= IndentAmount;
        }

        public static void HeaderSeparator()
        {
            EditorGUILayout.Separator();
            EditorGUILayout.Separator();
        }

        public static void SetKeyword(Material mat, string keyword, bool state)
        {
            if (state)
            {
                mat.EnableKeyword(keyword);
            }
            else
            {
                mat.DisableKeyword(keyword);
            }
        }

        public static bool TryGetToggle(Material material, string property, bool defaultVal)
        {
            if (material.HasProperty(property))
            {
                return material.GetFloat(property) == 1.0f;
            }
            return defaultVal;
        }
    }
}