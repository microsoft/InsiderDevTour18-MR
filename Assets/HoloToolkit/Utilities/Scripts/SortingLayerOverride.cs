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

namespace HoloToolkit.Unity
{
    /// <summary>
    /// Overrides the sorting layer of all renderers and child renderers
    /// </summary>
    public class SortingLayerOverride : MonoBehaviour
    {
        // Grabs the last layer in the project
        public bool UseLastLayer = false;

        // Only is used if UseLastLayer is false
        public string TargetSortingLayerName = "Default";

        [SerializeField]
        private Renderer[] renderers;

        private void Start()
        {
            if (renderers == null || renderers.Length == 0)
            {
                renderers = GetComponentsInChildren<Renderer>();
            }

            if (UseLastLayer && SortingLayer.layers.Length > 0)
            {
                var lastSortingLayer = SortingLayer.layers[SortingLayer.layers.Length - 1];
                TargetSortingLayerName = lastSortingLayer.name;
            }

            // Set sorting layer name in each child renderer
            foreach (var componentRenderer in renderers)
            {
                componentRenderer.sortingLayerName = TargetSortingLayerName;
            }
        }
    }
}
