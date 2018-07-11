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

namespace HoloToolkit.Unity
{
    public class CertificatePasswordWindow : EditorWindow
    {
        private static readonly GUILayoutOption LabelWidth = GUILayout.Width(110f);

        private static readonly GUILayoutOption ButtonWidth = GUILayout.Width(110f);

        private string path;

        private string password;

        private GUIContent message;

        private GUIStyle messageStyle;

        private string focus;

        public static void Show(string path)
        {
            CertificatePasswordWindow[] array = (CertificatePasswordWindow[])Resources.FindObjectsOfTypeAll(typeof(CertificatePasswordWindow));
            CertificatePasswordWindow certificatePasswordWindow = (array.Length <= 0) ? CreateInstance<CertificatePasswordWindow>() : array[0];
            path = path.Replace("\\", "/");
            certificatePasswordWindow.path = path.Substring(path.LastIndexOf("Assets/", StringComparison.Ordinal));
            certificatePasswordWindow.password = string.Empty;
            certificatePasswordWindow.message = GUIContent.none;
            certificatePasswordWindow.messageStyle = new GUIStyle(GUI.skin.label);
            certificatePasswordWindow.messageStyle.fontStyle = FontStyle.Italic;
            certificatePasswordWindow.focus = "password";
            if (array.Length > 0)
            {
                certificatePasswordWindow.Focus();
            }
            else
            {
                certificatePasswordWindow.titleContent = new GUIContent("Enter Windows Store Certificate Password");
                certificatePasswordWindow.position = new Rect(100f, 100f, 350f, 90f);
                certificatePasswordWindow.minSize = new Vector2(certificatePasswordWindow.position.width, certificatePasswordWindow.position.height);
                certificatePasswordWindow.maxSize = certificatePasswordWindow.minSize;
                certificatePasswordWindow.ShowUtility();
            }
        }

        public void OnGUI()
        {
            Event current = Event.current;
            bool flag = false;
            bool flag2 = false;

            if (current.type == EventType.KeyDown)
            {
                flag = (current.keyCode == KeyCode.Escape);
                flag2 = (current.keyCode == KeyCode.Return || current.keyCode == KeyCode.KeypadEnter);
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                GUILayout.Space(10f);
                using (new EditorGUILayout.VerticalScope())
                {
                    GUILayout.FlexibleSpace();
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        GUILayout.Label(new GUIContent("Password|Certificate password."), LabelWidth);
                        GUI.SetNextControlName("password");
                        password = GUILayout.PasswordField(password, '●');
                    }
                    GUILayout.Space(10f);
                    using (new EditorGUILayout.HorizontalScope())
                    {
                        GUILayout.Label(message, messageStyle);
                        GUILayout.FlexibleSpace();
                        if (GUILayout.Button(new GUIContent("Ok"), ButtonWidth) || flag2)
                        {
                            message = GUIContent.none;
                            try
                            {
                                if (PlayerSettings.WSA.SetCertificate(path, password))
                                {
                                    flag = true;
                                }
                                else
                                {
                                    message = new GUIContent("Invalid password.");
                                }
                            }
                            catch (UnityException ex)
                            {
                                Debug.LogError(ex.Message);
                            }
                        }
                    }
                    GUILayout.FlexibleSpace();
                }
                GUILayout.Space(10f);
            }

            if (flag)
            {
                Close();
            }
            else if (focus != null)
            {
                EditorGUI.FocusTextInControl(focus);
                focus = null;
            }
        }
    }
}