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
using HoloToolkit.Sharing.SyncModel;

namespace HoloToolkit.Sharing.Spawning
{
    /// <summary>
    /// A SpawnManager is in charge of spawning the appropriate objects based on changes to an array of data model objects
    /// to which it is registered.
    /// It also manages the lifespan of these spawned objects.
    /// </summary>
    /// <typeparam name="T">Type of SyncObject in the array being monitored by the SpawnManager.</typeparam>
    public abstract class SpawnManager<T> : MonoBehaviour where T : SyncObject, new()
    {
        protected SharingStage NetworkManager { get; private set; }

        protected SyncArray<T> SyncSource;

        protected List<GameObject> SyncSpawnObjectListInternal = new List<GameObject>(0);

        public bool IsSpawningObjects { get; protected set; }

        public List<GameObject> SyncSpawnObjectList { get { return SyncSpawnObjectListInternal; } }

        protected virtual void Start()
        {
            // SharingStage should be valid at this point, but we may not be connected.
            NetworkManager = SharingStage.Instance;
            if (NetworkManager.IsConnected)
            {
                Connected();
            }
            else
            {
                NetworkManager.SharingManagerConnected += Connected;
            }
        }

        protected virtual void Connected(object sender = null, EventArgs e = null)
        {
            if (SyncSource != null)
            {
                IsSpawningObjects = true;
                UnRegisterToDataModel();

                for (var i = 0; i < SyncSpawnObjectListInternal.Count; i++)
                {
                    Destroy(SyncSpawnObjectListInternal[i]);
                }

                SyncSpawnObjectListInternal.Clear();
            }

            SetDataModelSource();
            RegisterToDataModel();

            if (IsSpawningObjects)
            {
                ReSpawnObjects();
                IsSpawningObjects = false;
            }
        }

        /// <summary>
        /// Sets the data model source for the spawn manager.
        /// </summary>
        protected abstract void SetDataModelSource();

        /// <summary>
        /// Register to data model updates;
        /// </summary>
        private void RegisterToDataModel()
        {
            SyncSource.ObjectAdded += OnObjectAdded;
            SyncSource.ObjectRemoved += OnObjectRemoved;
        }

        private void UnRegisterToDataModel()
        {
            SyncSource.ObjectAdded -= OnObjectAdded;
            SyncSource.ObjectRemoved -= OnObjectRemoved;
        }

        private void OnObjectAdded(T addedObject)
        {
            InstantiateFromNetwork(addedObject);
        }

        private void OnObjectRemoved(T removedObject)
        {
            RemoveFromNetwork(removedObject);
        }

        private void ReSpawnObjects()
        {
            T[] objs = SyncSource.GetDataArray();

            for (var i = 0; i < objs.Length; i++)
            {
                InstantiateFromNetwork(objs[i]);
            }
        }

        /// <summary>
        /// Delete the data model for an object and all its related game objects.
        /// </summary>
        /// <param name="objectToDelete">Object that needs to be deleted.</param>
        public abstract void Delete(T objectToDelete);

        /// <summary>
        /// Instantiate game objects based on data model that was created on the network.
        /// </summary>
        /// <param name="addedObject">Object that was added to the data model.</param>
        protected abstract void InstantiateFromNetwork(T addedObject);

        /// <summary>
        /// Remove an object based on data model that was removed on the network.
        /// </summary>
        /// <param name="removedObject">Object that was removed from the data model.</param>
        protected abstract void RemoveFromNetwork(T removedObject);
    }
}
