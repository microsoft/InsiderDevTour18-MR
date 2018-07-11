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
using UnityEngine;
using HoloToolkit.Sharing.SyncModel;

namespace HoloToolkit.Sharing.Spawning
{
    /// <summary>
    /// This array is meant to hold SyncSpawnedObject and objects of subclasses.
    /// Compared to SyncArray, this supports dynamic types for objects.
    /// </summary>
    /// <typeparam name="T">Type of object that the array contains</typeparam>
    public class SyncSpawnArray<T> : SyncArray<T> where T : SyncSpawnedObject, new()
    {
        public SyncSpawnArray(string field) : base(field) { }

        public SyncSpawnArray() : base(string.Empty) { }

        protected override T CreateObject(ObjectElement objectElement)
        {
            string objectType = objectElement.GetObjectType();

            Type typeToInstantiate = Type.GetType(objectType);
            if (typeToInstantiate == null)
            {
                Debug.LogError("Could not find the SyncModel type to instantiate.");
                return null;
            }

            object createdObject = Activator.CreateInstance(typeToInstantiate);

            T spawnedDataModel = (T)createdObject;
            spawnedDataModel.Element = objectElement;
            spawnedDataModel.FieldName = objectElement.GetName();
            // TODO: this should not query SharingStage, but instead query the underlying session layer
            spawnedDataModel.Owner = SharingStage.Instance.SessionUsersTracker.GetUserById(objectElement.GetOwnerID());

            return spawnedDataModel;
        }
    }
}