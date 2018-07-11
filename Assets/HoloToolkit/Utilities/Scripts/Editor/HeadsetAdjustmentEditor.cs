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
using Object = UnityEngine.Object;

namespace HoloToolkit.Unity
{
    [CustomEditor(typeof(HeadsetAdjustment))]
    public class HeadsetAdjustmentEditor : Editor
    {
        private static SceneAsset sceneAsset;
        private static Object sceneObj;
        private static HeadsetAdjustment myTarget;

        private void OnEnable()
        {
            myTarget = (HeadsetAdjustment)target;
            sceneAsset = GetSceneObject(myTarget.NextSceneName);
        }

        public override void OnInspectorGUI()
        {
            sceneObj = EditorGUILayout.ObjectField(
                new GUIContent("Next Scene", "The name of the scene to load when the user is ready. If left empty, " +
                                             "the next scene is loaded as specified in the 'Scenes in Build')"),
                sceneAsset,
                typeof(SceneAsset),
                true);

            if (GUI.changed)
            {
                if (sceneObj == null)
                {
                    sceneAsset = null;
                    myTarget.NextSceneName = string.Empty;
                }
                else
                {
                    sceneAsset = GetSceneObject(sceneObj.name);
                    myTarget.NextSceneName = sceneObj.name;
                }
            }
        }

        private static SceneAsset GetSceneObject(string sceneObjectName)
        {
            if (string.IsNullOrEmpty(sceneObjectName))
            {
                return null;
            }

            foreach (EditorBuildSettingsScene editorScene in EditorBuildSettings.scenes)
            {
                if (editorScene.path.IndexOf(sceneObjectName, StringComparison.Ordinal) != -1)
                {
                    return AssetDatabase.LoadAssetAtPath(editorScene.path, typeof(SceneAsset)) as SceneAsset;
                }
            }

            Debug.LogWarning("Scene [" + sceneObjectName + "] cannot be used.  To use this scene add it to the build settings for the project.");
            return null;
        }
    }
}
