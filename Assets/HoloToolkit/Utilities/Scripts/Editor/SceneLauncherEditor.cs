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

using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace HoloToolkit.Unity
{
    [CustomEditor(typeof(SceneLauncher))]
    public class SceneLauncherEditor : Editor
    {
        private SerializedProperty sceneMappingProperty;
        private SerializedProperty buttonSpawnLocationProperty;
        private SerializedProperty buttonPrefabProperty;
        private SerializedProperty buttonRowMaxProperty;

        private void OnEnable()
        {
            sceneMappingProperty = serializedObject.FindProperty("sceneMapping");
            buttonSpawnLocationProperty = serializedObject.FindProperty("ButtonSpawnLocation");
            buttonPrefabProperty = serializedObject.FindProperty("SceneButtonPrefab");
            buttonRowMaxProperty = serializedObject.FindProperty("MaxRows");

            CheckBuildScenes(sceneMappingProperty);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(buttonSpawnLocationProperty);
            EditorGUILayout.PropertyField(buttonPrefabProperty);
            EditorGUILayout.IntSlider(buttonRowMaxProperty, 1, 10);
            EditorGUILayout.HelpBox("To add scenes to the Scene Mapper by adding scenes in the build window.", MessageType.Info);
            CheckBuildScenes(sceneMappingProperty);
            ShowSceneList(sceneMappingProperty);
            serializedObject.ApplyModifiedProperties();
        }

        private void ShowSceneList(SerializedProperty sceneList)
        {
            // property name with expansion widget
            EditorGUILayout.PropertyField(sceneList);

            if (EditorBuildSettings.scenes.Length == 0)
            {
                sceneList.ClearArray();

                int index = sceneList.arraySize;

                sceneList.InsertArrayElementAtIndex(index);
                sceneList.GetArrayElementAtIndex(index).FindPropertyRelative("ScenePath").stringValue = SceneManager.GetActiveScene().path;
                sceneList.GetArrayElementAtIndex(index).FindPropertyRelative("IsButtonEnabled").boolValue = true;

                EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(SceneManager.GetActiveScene().path, true) };
            }

            if (sceneList.isExpanded)
            {
                EditorGUI.indentLevel++;

                // Scene rows
                for (int i = 0; i < sceneList.arraySize; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    // Disable the toggle if the scene is not enabled in the build settings.
                    GUI.enabled = EditorBuildSettings.scenes[i].enabled;

                    EditorGUILayout.PropertyField(sceneList.GetArrayElementAtIndex(i).FindPropertyRelative("IsButtonEnabled"));

                    GUI.enabled = false;

                    string path = sceneList.GetArrayElementAtIndex(i).FindPropertyRelative("ScenePath").stringValue;
                    var sceneAsset = AssetDatabase.LoadAssetAtPath(path, typeof(SceneAsset)) as SceneAsset;
                    EditorGUILayout.ObjectField(sceneAsset, typeof(SceneAsset), false);

                    GUI.enabled = true;
                    EditorGUILayout.EndHorizontal();
                }

                EditorGUI.indentLevel--;
            }
        }

        private void CheckBuildScenes(SerializedProperty list)
        {
            if (EditorBuildSettings.scenes.Length == 0)
            {
                return;
            }

            bool reBuildList = list.arraySize != EditorBuildSettings.scenes.Length;

            if (!reBuildList)
            {
                // Check if the build settings list is the same as ours.
                for (int i = 0; i < list.arraySize; i++)
                {
                    if (list.GetArrayElementAtIndex(i).FindPropertyRelative("ScenePath").stringValue != EditorBuildSettings.scenes[i].path)
                    {
                        reBuildList = true;
                    }
                }
            }

            if (reBuildList)
            {
                // if it's not then we need to store a copy of our mappings.
                var oldBuildSceneMapping = new EditorBuildSettingsScene[list.arraySize];
                for (int i = 0; i < list.arraySize; i++)
                {
                    oldBuildSceneMapping[i] = new EditorBuildSettingsScene
                    {
                        path = list.GetArrayElementAtIndex(i).FindPropertyRelative("ScenePath").stringValue,
                        enabled = list.GetArrayElementAtIndex(i).FindPropertyRelative("IsButtonEnabled").boolValue
                    };
                }

                // Then re assign the mapping to the right scene in the build settings window.
                list.ClearArray();

                for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
                {
                    list.InsertArrayElementAtIndex(i);
                    list.GetArrayElementAtIndex(i).FindPropertyRelative("ScenePath").stringValue = EditorBuildSettings.scenes[i].path;
                    list.GetArrayElementAtIndex(i).FindPropertyRelative("IsButtonEnabled").boolValue = false;

                    for (var j = 0; j < oldBuildSceneMapping.Length; j++)
                    {
                        if (oldBuildSceneMapping[j].path == EditorBuildSettings.scenes[i].path)
                        {
                            list.GetArrayElementAtIndex(i).FindPropertyRelative("IsButtonEnabled").boolValue = oldBuildSceneMapping[j].enabled;
                        }
                    }
                }
            }
        }
    }
}
