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
    // Displays an int or float property as a range
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class RangePropAttribute : DrawOverrideAttribute
    {

        public enum TypeEnum
        {
            Float,
            Int,
        }

        public float MinFloat { get; private set; }
        public float MaxFloat { get; private set; }
        public int MinInt { get; private set; }
        public int MaxInt { get; private set; }
        public TypeEnum Type { get; private set; }

        public RangePropAttribute(float min, float max)
        {
            MinFloat = min;
            MaxFloat = max;
            Type = TypeEnum.Float;
        }

        public RangePropAttribute(int min, int max)
        {
            MinInt = min;
            MaxInt = max;
            Type = TypeEnum.Int;
        }

#if UNITY_EDITOR
        public override void DrawEditor(UnityEngine.Object target, FieldInfo field, SerializedProperty property)
        {
            // (safe since this is property-only attribute)
            throw new NotImplementedException();
        }

        public override void DrawEditor(UnityEngine.Object target, PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(int))
            {
                int propIntValue = (int)prop.GetValue(target, null);
                propIntValue = EditorGUILayout.IntSlider(SplitCamelCase(prop.Name), propIntValue, MinInt, MaxInt);
                prop.SetValue(target, propIntValue, null);
            }
            else if (prop.PropertyType == typeof(float))
            {
                float propFloatValue = (float)prop.GetValue(target, null);
                propFloatValue = EditorGUILayout.Slider(SplitCamelCase(prop.Name), propFloatValue, MinFloat, MaxFloat);
                prop.SetValue(target, propFloatValue, null);
            }
        }
#endif

    }
}