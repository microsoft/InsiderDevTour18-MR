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
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Provides the input meshes to the spatial understanding DLL.
    /// The component relies on the spatial mapping module. It maintains
    /// a mesh list in the required DLL format which is updated from 
    /// the spatial mapping's SurfaceObject list.
    /// </summary>
    public class SpatialUnderstandingSourceMesh : MonoBehaviour
    {
        // Privates
        /// <summary>
        /// Internal list of meshes that is passed to the DLL. This is
        /// kept up to date with spatial mapping's SurfaceObject list.
        /// </summary>
        private readonly List<SpatialUnderstandingDll.MeshData> inputMeshList = new List<SpatialUnderstandingDll.MeshData>();

        // Functions
        private void Start()
        {
            TryAttach(SpatialMappingManager.Instance.Source);
            SpatialMappingManager.Instance.SourceChanged += HandleSpatialMappingSourceChanged;
        }

        private void HandleSpatialMappingSourceChanged(object sender, PropertyChangedEventArgsEx<SpatialMappingSource> e)
        {
            Debug.Assert(object.ReferenceEquals(sender, SpatialMappingManager.Instance));

            TryDetach(e.OldValue);
            TryAttach(e.NewValue);
        }

        private void TryDetach(SpatialMappingSource spatialMappingSource)
        {
            if (spatialMappingSource != null)
            {
                spatialMappingSource.SurfaceAdded -= HandleSurfaceAdded;
                spatialMappingSource.SurfaceUpdated -= HandleSurfaceUpdated;
                spatialMappingSource.SurfaceRemoved -= HandleSurfaceRemoved;
                spatialMappingSource.RemovingAllSurfaces -= HandleRemovingAllSurfaces;
            }

            inputMeshList.Clear();
        }

        private void TryAttach(SpatialMappingSource spatialMappingSource)
        {
            if (spatialMappingSource != null)
            {
                spatialMappingSource.SurfaceAdded += HandleSurfaceAdded;
                spatialMappingSource.SurfaceUpdated += HandleSurfaceUpdated;
                spatialMappingSource.SurfaceRemoved += HandleSurfaceRemoved;
                spatialMappingSource.RemovingAllSurfaces += HandleRemovingAllSurfaces;

                Debug.Assert(inputMeshList.Count == 0);

                foreach (var surface in spatialMappingSource.SurfaceObjects)
                {
                    inputMeshList.Add(CreateMeshData(surface, meshUpdateID: 0));
                }
            }
        }

        private void HandleSurfaceAdded(object sender, DataEventArgs<SpatialMappingSource.SurfaceObject> e)
        {
            Debug.Assert(object.ReferenceEquals(sender, SpatialMappingManager.Instance.Source));
            Debug.Assert(FindMeshIndexInInputMeshList(e.Data.ID) < 0);

            inputMeshList.Add(CreateMeshData(e.Data, meshUpdateID: 0));
        }

        private void HandleSurfaceUpdated(object sender, DataEventArgs<SpatialMappingSource.SurfaceUpdate> e)
        {
            Debug.Assert(object.ReferenceEquals(sender, SpatialMappingManager.Instance.Source));
            Debug.Assert(e.Data.Old.ID == e.Data.New.ID);

            int iMesh = FindMeshIndexInInputMeshList(e.Data.New.ID);
            Debug.Assert(iMesh >= 0);

            inputMeshList[iMesh] = CreateMeshData(e.Data.New, (inputMeshList[iMesh].LastUpdateID + 1));
        }

        private void HandleSurfaceRemoved(object sender, DataEventArgs<SpatialMappingSource.SurfaceObject> e)
        {
            Debug.Assert(object.ReferenceEquals(sender, SpatialMappingManager.Instance.Source));

            var iMesh = FindMeshIndexInInputMeshList(e.Data.ID);
            Debug.Assert(iMesh >= 0);

            inputMeshList.RemoveAt(iMesh);
        }

        private void HandleRemovingAllSurfaces(object sender, EventArgs e)
        {
            Debug.Assert(object.ReferenceEquals(sender, SpatialMappingManager.Instance.Source));

            inputMeshList.Clear();
        }

        private int FindMeshIndexInInputMeshList(int meshID)
        {
            for (int i = 0; i < inputMeshList.Count; ++i)
            {
                if (inputMeshList[i].MeshID == meshID)
                {
                    return i;
                }
            }
            return -1;
        }

        private static SpatialUnderstandingDll.MeshData CreateMeshData(SpatialMappingSource.SurfaceObject surface, int meshUpdateID)
        {
            MeshFilter meshFilter = surface.Filter;
            SpatialUnderstandingDll.MeshData meshData = new SpatialUnderstandingDll.MeshData();

            if ((meshFilter != null) &&
                (meshFilter.mesh != null) &&
                (meshFilter.mesh.triangles.Length > 0))
            {
                // Fix surface mesh normals so we can get correct plane orientation.
                meshFilter.mesh.RecalculateNormals();

                // Convert
                meshData.CopyFrom(meshFilter, surface.ID, meshUpdateID);
            }
            else
            {
                // No filter yet, add as an empty mesh (will be updated later in the update loop)
                meshData.CopyFrom(null, surface.ID, meshUpdateID);
            }

            return meshData;
        }

        /// <summary>
        /// Update the internal mesh list and provides an array pointer in
        /// the form the DLL will accept.
        /// </summary>
        /// <param name="meshCount">Number of meshes contains in the return mesh list</param>
        /// <param name="meshList">Marshalled mesh list pointer. Valid only with the caller's function context</param>
        /// <returns></returns>
        public bool GetInputMeshList(out int meshCount, out IntPtr meshList)
        {
            if (inputMeshList.Count == 0)
            {
                meshCount = 0;
                meshList = IntPtr.Zero;
                return false;
            }

            // Convert to IntPtr
            SpatialUnderstandingDll dll = SpatialUnderstanding.Instance.UnderstandingDLL;
            meshCount = inputMeshList.Count;
            meshList = dll.PinMeshDataForMarshalling(inputMeshList);

            return true;
        }
    }
}