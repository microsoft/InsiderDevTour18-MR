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

using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.Buttons
{
    /// <summary>
    /// Concrete version of Button class used with other CompoundButton scripts (e.g., CompoundButtonMesh)
    /// Also contains fields for commonly referenced components
    /// </summary>
    public class CompoundButton : Button
    {
        [Tooltip("The button's 'main' collider - not required, but useful for judging scale and enabling / disabling")]
        [DropDownComponent]
        public Collider MainCollider;

        [Tooltip("The button's 'main' renderer - not required, but useful for judging material properties")]
        [DropDownComponent]
        public MeshRenderer MainRenderer;

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(CompoundButton))]
        public class CustomEditor : MRTKEditor
        {
            /// <summary>
            /// Validate button settings to ensure button will work in current scene
            /// TODO strengthen this check against new MRTK system
            /// </summary>
            protected override void DrawCustomFooter() {

                CompoundButton cb = (CompoundButton)target;

                // Don't perform this check at runtime
                if (!Application.isPlaying) {
                    // First, check our colliders
                    // Get the components we need for the button to be visible
                    Rigidbody parentRigidBody = cb.GetComponent<Rigidbody>();
                    Collider parentCollider = cb.GetComponent<Collider>();
                    // Get all child colliders that AREN'T the parent collider
                    HashSet<Collider> childColliders = new HashSet<Collider>(cb.GetComponentsInChildren<Collider>());
                    childColliders.Remove(parentCollider);

                    bool foundError = false;
                    UnityEditor.EditorGUILayout.BeginVertical(UnityEditor.EditorStyles.helpBox);
                    if (parentCollider == null) {
                        if (childColliders.Count == 0) {
                            foundError = true;
                            DrawError("Button must have at least 1 collider to be visible, preferably on the root transform.");
                            if (GUILayout.Button("Fix now")) {
                                cb.gameObject.AddComponent<BoxCollider>();
                            }
                        } else if (parentRigidBody == null) {
                            foundError = true;
                            DrawError("Button requires a Rigidbody if colliders are only present on child transforms.");
                            if (GUILayout.Button("Fix now")) {
                                Rigidbody rb = cb.gameObject.AddComponent<Rigidbody>();
                                rb.isKinematic = true;
                            }
                        } else if (!parentRigidBody.isKinematic) {
                            foundError = true;
                            GUI.color = warningColor;
                            DrawWarning("Warning: Button rigid body is not kinematic - this is not recommended.");
                            if (GUILayout.Button("Fix now")) {
                                parentRigidBody.isKinematic = true;
                            }
                        }
                    }

                    if (!foundError) {
                        GUI.color = successColor;
                        UnityEditor.EditorGUILayout.LabelField("Button is good to go!", UnityEditor.EditorStyles.wordWrappedLabel);
                    }
                    UnityEditor.EditorGUILayout.EndVertical();
                }
            }
        }
#endif
    }
}