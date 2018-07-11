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
using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HoloToolkit.Unity
{
    // Displays a prop as editable in the inspector
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class EditablePropAttribute : DrawOverrideAttribute
    {
        public string CustomLabel { get; private set; }

        public EditablePropAttribute(string customLabel = null)
        {
            CustomLabel = customLabel;
        }

#if UNITY_EDITOR
        public override void DrawEditor(UnityEngine.Object target, FieldInfo field, SerializedProperty property)
        {
            // (safe since this is property-only attribute)
            throw new NotImplementedException();
        }

        public override void DrawEditor(UnityEngine.Object target, PropertyInfo prop)
        {
            switch (prop.PropertyType.Name)
            {
                case "Boolean":
                    bool boolValue = (bool)prop.GetValue(target, null);
                    boolValue = EditorGUILayout.Toggle(!string.IsNullOrEmpty (CustomLabel) ? CustomLabel : SplitCamelCase(prop.Name), boolValue);
                    prop.SetValue(target, boolValue, null);
                    break;

                case "Int32":
                    int intValue = (int)prop.GetValue(target, null);
                    intValue = EditorGUILayout.IntField(!string.IsNullOrEmpty(CustomLabel) ? CustomLabel : SplitCamelCase(prop.Name), intValue);
                    prop.SetValue(target, intValue, null);
                    break;

                case "Single":
                    float singleValue = (float)prop.GetValue(target, null);
                    singleValue = EditorGUILayout.FloatField(!string.IsNullOrEmpty(CustomLabel) ? CustomLabel : SplitCamelCase(prop.Name), singleValue);
                    prop.SetValue(target, singleValue, null);
                    break;

                default:
                    throw new NotImplementedException("No drawer for type " + prop.PropertyType.Name);
            }
        }
#endif

    }
}