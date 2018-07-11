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

namespace HoloToolkit.Unity
{
    public static class EditorPrefsUtility
    {
        public static void SetEditorPref(string key, string value)
        {
            EditorPrefs.SetString(Application.productName + key, value);
        }

        public static void SetEditorPref(string key, bool value)
        {
            EditorPrefs.SetBool(Application.productName + key, value);
        }

        public static void SetEditorPref(string key, float value)
        {
            EditorPrefs.SetFloat(Application.productName + key, value);
        }

        public static void SetEditorPref(string key, int value)
        {
            EditorPrefs.SetInt(Application.productName + key, value);
        }

        public static string GetEditorPref(string key, string defaultValue)
        {
            if (EditorPrefs.HasKey(Application.productName + key))
            {
                return EditorPrefs.GetString(Application.productName + key);
            }

            EditorPrefs.SetString(Application.productName + key, defaultValue);
            return defaultValue;
        }

        public static bool GetEditorPref(string key, bool defaultValue)
        {
            if (EditorPrefs.HasKey(Application.productName + key))
            {
                return EditorPrefs.GetBool(Application.productName + key);
            }

            EditorPrefs.SetBool(Application.productName + key, defaultValue);
            return defaultValue;
        }

        public static float GetEditorPref(string key, float defaultValue)
        {
            if (EditorPrefs.HasKey(Application.productName + key))
            {
                return EditorPrefs.GetFloat(Application.productName + key);
            }

            EditorPrefs.SetFloat(Application.productName + key, defaultValue);
            return defaultValue;
        }

        public static int GetEditorPref(string key, int defaultValue)
        {
            if (EditorPrefs.HasKey(Application.productName + key))
            {
                return EditorPrefs.GetInt(Application.productName + key);
            }

            EditorPrefs.SetInt(Application.productName + key, defaultValue);
            return defaultValue;
        }
    }
}
