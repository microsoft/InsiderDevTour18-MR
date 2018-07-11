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
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HoloToolkit.Unity
{
    // Displays a drop-down menu of Component objects that are limited to the target object
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class DropDownComponentAttribute : DrawOverrideAttribute
    {
        public bool AutoFill { get; private set; }
        public bool ShowComponentNames { get; private set; }
        public string CustomLabel { get; private set; }

        public DropDownComponentAttribute(bool showComponentNames = false, bool autoFill = false, string customLabel = null)
        {
            ShowComponentNames = showComponentNames;
            CustomLabel = customLabel;
            AutoFill = autoFill;
        }

#if UNITY_EDITOR
        public override void DrawEditor(UnityEngine.Object target, FieldInfo field, SerializedProperty property)
        {
            Transform transform = (target as Component).transform;

            Component componentValue = field.GetValue(target) as Component;

            Type targetType = field.FieldType;
            if (targetType == typeof(MonoBehaviour))
                targetType = typeof(Component);

            if (componentValue == null && AutoFill)
            {
                componentValue = transform.GetComponentInChildren(targetType) as Component;
            }

            componentValue = DropDownComponentField(
                SplitCamelCase(field.Name),
                componentValue,
                targetType,
                transform,
                ShowComponentNames);
            field.SetValue(target, componentValue);
        }

        public override void DrawEditor(UnityEngine.Object target, PropertyInfo prop)
        {
            Transform transform = (target as Component).transform;

            Component componentValue = prop.GetValue(target, null) as Component;

            Type targetType = prop.PropertyType;
            if (targetType == typeof(MonoBehaviour))
                targetType = typeof(Component);

            if (componentValue == null && AutoFill)
            {
                componentValue = transform.GetComponentInChildren(targetType) as Component;
            }

            componentValue = DropDownComponentField(
                SplitCamelCase(prop.Name),
                componentValue,
                targetType,
                transform,
                ShowComponentNames);
            prop.SetValue(target, componentValue, null);
        }

        private static Component DropDownComponentField(string label, Component obj, Type componentType, Transform transform, bool showComponentName = false)
        {
            Component[] optionObjects = transform.GetComponentsInChildren(componentType, true);
            int selectedIndex = 0;
            string[] options = new string[optionObjects.Length + 1];
            options[0] = "(None)";
            for (int i = 0; i < optionObjects.Length; i++)
            {
                if (showComponentName)
                {
                    options[i + 1] = optionObjects[i].GetType().Name + " (" + optionObjects[i].name + ")";
                }
                else
                {
                    options[i + 1] = optionObjects[i].name;
                }
                if (obj == optionObjects[i])
                {
                    selectedIndex = i + 1;
                }
            }

            EditorGUILayout.BeginHorizontal();
            int newIndex = EditorGUILayout.Popup(label, selectedIndex, options);
            if (newIndex == 0)
            {
                // Zero means '(None)'
                obj = null;
            }
            else
            {
                obj = optionObjects[newIndex - 1];
            }

            //draw the object field so people can click it
            obj = (Component)EditorGUILayout.ObjectField(obj, componentType, true);
            EditorGUILayout.EndHorizontal();

            return obj;
        }
#endif
    }
}