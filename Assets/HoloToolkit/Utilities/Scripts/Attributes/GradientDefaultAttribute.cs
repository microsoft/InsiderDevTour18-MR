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
    // Adds a 'default' button to a color gradient that will supply default color values
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class GradientDefaultAttribute : DrawOverrideAttribute
    {
        // Used because you can't pass colors as attribute vars :/
        public enum ColorEnum
        {
            Black,
            Blue,
            Clear,
            Cyan,
            Gray,
            Green,
            Magenta,
            Red,
            White,
            Yellow
        }

        public GradientDefaultAttribute(ColorEnum startColor, ColorEnum endColor, float startAlpha = 1f, float endAlpha = 1f)
        {
            this.startColor = GetColor(startColor);
            this.endColor = GetColor(endColor);
            this.startColor.a = startAlpha;
            this.endColor.a = endAlpha;
        }

#if UNITY_EDITOR
        public override void DrawEditor(UnityEngine.Object target, FieldInfo field, SerializedProperty property)
        {
            Gradient gradientValue = field.GetValue(target) as Gradient;

            if (gradientValue == null || gradientValue.colorKeys == null || gradientValue.colorKeys.Length == 0)
                gradientValue = GetDefault();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(property);
            if (GUILayout.Button("Default"))
            {
                gradientValue = GetDefault();
            }
            EditorGUILayout.EndHorizontal();

            field.SetValue(target, gradientValue);
        }

        public override void DrawEditor(UnityEngine.Object target, PropertyInfo prop)
        {
            throw new NotImplementedException();
        }
#endif

        private Gradient GetDefault()
        {
            Gradient gradient = new Gradient();
            GradientColorKey[] colorKeys = new GradientColorKey[2] {
                    new GradientColorKey(startColor, 0f),
                    new GradientColorKey(endColor, 1f)
                };
            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2]
            {
                    new GradientAlphaKey(startColor.a, 0f),
                    new GradientAlphaKey(endColor.a, 0f),
            };
            gradient.SetKeys(colorKeys, alphaKeys);
            return gradient;
        }

        private Color startColor;
        private Color endColor;

        private static Color GetColor(ColorEnum color)
        {
            switch (color)
            {
                case ColorEnum.Black:
                    return Color.black;
                case ColorEnum.Blue:
                    return Color.blue;
                case ColorEnum.Clear:
                default:
                    return Color.clear;
                case ColorEnum.Cyan:
                    return Color.cyan;
                case ColorEnum.Gray:
                    return Color.gray;
                case ColorEnum.Green:
                    return Color.green;
                case ColorEnum.Magenta:
                    return Color.magenta;
                case ColorEnum.Red:
                    return Color.red;
                case ColorEnum.White:
                    return Color.white;
                case ColorEnum.Yellow:
                    return Color.yellow;
            }
        }
    }
}