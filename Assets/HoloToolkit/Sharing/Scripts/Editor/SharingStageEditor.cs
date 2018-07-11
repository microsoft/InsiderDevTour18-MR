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

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using HoloToolkit.Sharing.SyncModel;

namespace HoloToolkit.Sharing
{
    [CustomEditor(typeof(SharingStage))]
    public class SharingStageEditor : Editor
    {
        private Dictionary<object, bool> foldoutGUIMap = new Dictionary<object, bool>();

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (Application.isPlaying)
            {
                SharingStage networkManager = (SharingStage)target;

                SyncRoot root = networkManager.Root;

                if (root != null)
                {
                    EditorGUILayout.Separator();
                    EditorGUILayout.BeginVertical();
                    {
                        EditorGUILayout.LabelField("Object Hierarchy");
                        DrawDataModelGUI(root, string.Empty);
                    }
                    EditorGUILayout.EndVertical();
                }

                // Force this inspector to repaint every frame so that it reflects changes to the undo stack
                // immediately rather than showing stale data until the user clicks on the inspector window
                Repaint();
            }
        }

        private void DrawDataModelGUI(SyncPrimitive syncPrimitive, string parentPath)
        {
            string fieldName = syncPrimitive.FieldName;
            object rawValue = syncPrimitive.RawValue;

            SyncObject syncObject = syncPrimitive as SyncObject;

            if (syncObject != null)
            {
                bool foldout = false;
                if (foldoutGUIMap.ContainsKey(syncObject))
                {
                    foldout = foldoutGUIMap[syncObject];
                }

                int ownerId = syncObject.OwnerId;
                string owner = ownerId == int.MaxValue ? string.Empty : ownerId.ToString();
                string objectType = syncObject.ObjectType;

                foldout = EditorGUILayout.Foldout(foldout, string.Format("{0} (Owner:{1} Type:{2})", fieldName, owner, objectType));
                foldoutGUIMap[syncObject] = foldout;

                if (foldout)
                {
                    EditorGUI.indentLevel++;

                    SyncPrimitive[] children = syncObject.GetChildren();
                    for (int i = 0; i < children.Length; i++)
                    {
                        DrawDataModelGUI(children[i], parentPath + "/" + fieldName);
                    }

                    EditorGUI.indentLevel--;
                }
            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(fieldName, GUILayout.MaxWidth(125));
                EditorGUILayout.LabelField(rawValue != null ? rawValue.ToString() : "null", GUILayout.MaxWidth(200));
                EditorGUILayout.LabelField(syncPrimitive.NetworkElement != null ? "live" : "local", GUILayout.MaxWidth(50));
                if (syncPrimitive.NetworkElement != null)
                {
                    EditorGUILayout.LabelField(parentPath + "/" + fieldName, GUILayout.MaxWidth(500));
                }

                EditorGUILayout.EndHorizontal();
            }
        }
    }
}
