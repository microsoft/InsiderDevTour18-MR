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
using System.Linq;
using UnityEngine;

#if UNITY_WSA || UNITY_STANDALONE_WIN
using UnityEngine.Windows.Speech;
#endif

namespace HoloToolkit.Unity.SpatialMapping
{
    [RequireComponent(typeof(RemoteMeshTarget))]
    public partial class RemoteMappingManager : Singleton<RemoteMappingManager>
    {
        [Tooltip("Key to press in editor to enable spatial mapping over the network.")]
        public KeyCode RemoteMappingKey = KeyCode.N;

        [Tooltip("Keyword for sending meshes from HoloLens to Unity over the network.")]
        public string SendMeshesKeyword = "send meshes";

#if UNITY_EDITOR || UNITY_STANDALONE
        /// <summary>
        /// Receives meshes collected over the network.
        /// </summary>
        private RemoteMeshTarget remoteMeshTarget;
#endif

#if UNITY_WSA || UNITY_STANDALONE_WIN
        /// <summary>
        /// Used for voice commands.
        /// </summary>
        private KeywordRecognizer keywordRecognizer;

        /// <summary>
        /// Collection of supported keywords and their associated actions.
        /// </summary>
        private Dictionary<string, System.Action> keywordCollection;
#endif

        // Use this for initialization.
        private void Start()
        {
#if UNITY_WSA || UNITY_STANDALONE_WIN
            // Create our keyword collection.
            keywordCollection = new Dictionary<string, System.Action> { { SendMeshesKeyword, SendMeshes } };

            // Tell the KeywordRecognizer about our keywords.
            keywordRecognizer = new KeywordRecognizer(keywordCollection.Keys.ToArray());
            // Register a callback for the KeywordRecognizer and start recognizing.
            keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
            keywordRecognizer.Start();
#endif

#if UNITY_EDITOR || UNITY_STANDALONE
            remoteMeshTarget = GetComponent<RemoteMeshTarget>();

            if (remoteMeshTarget != null && SpatialMappingManager.Instance.Source == null)
            {
                // Use the network-based mapping source to receive meshes in the Unity editor.
                SpatialMappingManager.Instance.SetSpatialMappingSource(remoteMeshTarget);
            }
#endif
        }

        // Called every frame by the Unity engine.
        private void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            // Use the 'network' sourced mesh.  
            if (Input.GetKeyUp(RemoteMappingKey))
            {
                SpatialMappingManager.Instance.SetSpatialMappingSource(remoteMeshTarget);
            }
#endif
        }

#if UNITY_WSA || UNITY_STANDALONE_WIN
        /// <summary>
        /// Called by keywordRecognizer when a phrase we registered for is heard.
        /// </summary>
        /// <param name="args">Information about the recognition event.</param>
        private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
        {
            System.Action keywordAction;

            if (keywordCollection.TryGetValue(args.text, out keywordAction))
            {
                keywordAction.Invoke();
            }
        }
#endif

        /// <summary>
        /// Sends the spatial mapping surfaces from the HoloLens to a remote system running the Unity editor.
        /// </summary>
        private void SendMeshes()
        {
#if !UNITY_EDITOR && UNITY_WSA
            List<MeshFilter> MeshFilters = SpatialMappingManager.Instance.GetMeshFilters();
            for (int index = 0; index < MeshFilters.Count; index++)
            {
                List<Mesh> meshesToSend = new List<Mesh>();
                MeshFilter filter = MeshFilters[index];
                Mesh source = filter.sharedMesh;
                Mesh clone = new Mesh();
                List<Vector3> verts = new List<Vector3>();
                verts.AddRange(source.vertices);
            
                for(int vertIndex=0; vertIndex < verts.Count; vertIndex++)
                {
                    verts[vertIndex] = filter.transform.TransformPoint(verts[vertIndex]);
                }

                clone.SetVertices(verts); 
                clone.SetTriangles(source.triangles, 0);
                meshesToSend.Add(clone);
                byte[] serialized = SimpleMeshSerializer.Serialize(meshesToSend);
                RemoteMeshSource.Instance.SendData(serialized);
            }
#endif
        }
    }
}