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
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HoloToolkit.Unity.SpatialMapping
{
    public class FileSurfaceObserver : SpatialMappingSource
    {
        [Tooltip("The file name to use when saving and loading meshes.")]
        public string MeshFileName = "roombackup";

        [Tooltip("Key to press in editor to load a spatial mapping mesh from a .room file.")]
        public KeyCode LoadFileKey = KeyCode.L;

        [Tooltip("Key to press in editor to save a spatial mapping mesh to file.")]
        public KeyCode SaveFileKey = KeyCode.S;

        /// <summary>
        /// Loads the SpatialMapping mesh from the specified file.
        /// </summary>
        /// <param name="fileName">The name, without path or extension, of the file to load.</param>
        public void Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                Debug.Log("No mesh file specified.");
                return;
            }

            Cleanup();

            try
            {
                IList<Mesh> storedMeshes = MeshSaver.Load(fileName);

                for(int iMesh = 0; iMesh < storedMeshes.Count; iMesh++)
                {
                    AddSurfaceObject(CreateSurfaceObject(
                        mesh: storedMeshes[iMesh],
                        objectName: "storedmesh-" + iMesh,
                        parentObject: transform,
                        meshID: iMesh
                        ));
                }
            }
            catch
            {
                Debug.Log("Failed to load " + fileName);
            }
        }

        // Called every frame.
        private void Update()
        {
            // Keyboard commands for saving and loading a remotely generated mesh file.
#if UNITY_EDITOR || UNITY_STANDALONE
            // S - saves the active mesh
            if (Input.GetKeyUp(SaveFileKey))
            {
                MeshSaver.Save(MeshFileName, SpatialMappingManager.Instance.GetMeshes());
            }

            // L - loads the previously saved mesh into editor and sets it to be the spatial mapping source.
            if (Input.GetKeyUp(LoadFileKey))
            {
                SpatialMappingManager.Instance.SetSpatialMappingSource(this);
                Load(MeshFileName);
            }
#endif
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(FileSurfaceObserver))]
    public class FileSurfaceObserverEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            // Quick way for the user to get access to the room file location.
            if (GUILayout.Button("Open File Location"))
            {
                System.Diagnostics.Process.Start(MeshSaver.MeshFolderName);
            }
        }
    }
#endif
}