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
using System.Collections.Generic;
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HoloToolkit.Unity
{
    // Displays an enum value as a dropdown mask
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class EnumFlagsAttribute : DrawOverrideAttribute
    {
#if UNITY_EDITOR
        public override void DrawEditor(UnityEngine.Object target, FieldInfo field, SerializedProperty property)
        {
            int enumValue = Convert.ToInt32(field.GetValue(target));
            List<string> displayOptions = new List<string>();
            foreach (object value in Enum.GetValues(field.FieldType))
            {
                displayOptions.Add(value.ToString());
            }
            enumValue = EditorGUILayout.MaskField(SplitCamelCase(field.Name), enumValue, displayOptions.ToArray());
        }

        public override void DrawEditor(UnityEngine.Object target, PropertyInfo prop)
        {
            int enumValue = Convert.ToInt32(prop.GetValue(target, null));
            List<string> displayOptions = new List<string>();
            foreach (object value in Enum.GetValues(prop.PropertyType))
            {
                displayOptions.Add(value.ToString());
            }
            enumValue = EditorGUILayout.MaskField(SplitCamelCase(prop.Name), enumValue, displayOptions.ToArray());
        }
#endif
    }
}