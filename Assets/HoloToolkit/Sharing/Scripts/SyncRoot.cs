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

using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Sharing.SyncModel;

namespace HoloToolkit.Sharing
{
    /// <summary>
    /// Root of the synchronization data model used by this application.
    /// </summary>
    public class SyncRoot : SyncObject
    {
        /// <summary>
        /// Children of the root.
        /// </summary>
        [SyncData]
        public SyncArray<SyncSpawnedObject> InstantiatedPrefabs;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rootElement">Root Element from Sharing Stage</param>
        public SyncRoot(ObjectElement rootElement)
        {
            Element = rootElement;
            FieldName = Element.GetName().GetString();
            InitializeSyncSettings();
            InitializeDataModel();
        }

        private void InitializeSyncSettings()
        {
            SyncSettings.Instance.Initialize();
        }

        /// <summary>
        /// Initializes any data models that need to have a local state.
        /// </summary>
        private void InitializeDataModel()
        {
            InstantiatedPrefabs.InitializeLocal(Element);
        }
    }
}
