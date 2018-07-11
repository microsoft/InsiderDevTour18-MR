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

using HoloToolkit.Unity.InputModule;
using UnityEditor;
using UnityEngine;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Helper class to assign the UIRaycastCamera when creating a new canvas object and assigning the world space render mode.
    /// </summary>
    [CustomEditor(typeof(Canvas))]
    public class CanvasEditorExtension : Editor
    {
        private const string DialogText = "Hi there, we noticed that you've changed this canvas to use WorldSpace.\n\n" +
                                          "In order for the InputManager to work properly with uGUI raycasting we'd like to update this canvas' " +
                                          "WorldCamera to use the FocusManager's UIRaycastCamera.\n";

        private Canvas canvas;

        private void OnEnable()
        {
            canvas = (Canvas)target;
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            base.OnInspectorGUI();

            // We will only ask if we have a focus manager in our scene.
            if (EditorGUI.EndChangeCheck() && FocusManager.Instance)
            {
                FocusManager.AssertIsInitialized();
                bool removeHelper = false;

                // Update the world camera if we need to.
                if (canvas.isRootCanvas && canvas.renderMode == RenderMode.WorldSpace && canvas.worldCamera != FocusManager.Instance.UIRaycastCamera)
                {
                    if (EditorUtility.DisplayDialog("Attention!", DialogText, "OK", "Cancel"))
                    {
                        canvas.worldCamera = FocusManager.Instance.UIRaycastCamera;
                    }
                    else
                    {
                        removeHelper = true;
                    }
                }

                // Add the Canvas Helper if we need it.
                if (canvas.isRootCanvas && canvas.renderMode == RenderMode.WorldSpace && canvas.worldCamera == FocusManager.Instance.UIRaycastCamera)
                {
                    var helper = canvas.gameObject.EnsureComponent<CanvasHelper>();
                    helper.Canvas = canvas;
                }

                // Reset the world canvas if we need to.
                if (canvas.isRootCanvas && canvas.renderMode != RenderMode.WorldSpace && canvas.worldCamera == FocusManager.Instance.UIRaycastCamera)
                {
                    // Sets it back to MainCamera default.
                    canvas.worldCamera = null;
                    removeHelper = true;
                }

                // Remove the helper if we don't need it.
                if (removeHelper)
                {
                    // Remove the helper if needed.
                    var helper = canvas.GetComponent<CanvasHelper>();
                    if (helper != null)
                    {
                        DestroyImmediate(helper);
                    }
                }
            }
        }
    }
}
