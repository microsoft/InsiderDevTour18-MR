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

namespace HoloToolkit.Unity.Collections
{
    /// <summary>
    /// A utility that stores transform information for objects in a collection
    /// This info can then be used for non-destructive real-time manipulation
    /// Or to restore an earlier configuration gathered on startup
    /// </summary>
    public class ObjectCollectionDynamic : MonoBehaviour
    {
        public enum BehaviorEnum
        {
            StoreEveryTime,
            StoreOnceOnStartup,
            StoreManually,
        }

        /// <summary>
        /// Extends collection node class to include stored local position / rotation data
        /// </summary>
        [Serializable]
        public class CollectionNodeDynamic : CollectionNode
        {
            public CollectionNodeDynamic(CollectionNode node)
            {
                transform = node.transform;
                Name = node.Name;
                Offset = node.Offset;
                Radius = node.Radius;

                localPositionOnStartup = transform.localPosition;
                localEulerAnglesOnStartup = transform.localEulerAngles;
            }

            public CollectionNodeDynamic (Transform nodeTransform)
            {
                transform = nodeTransform;
                Name = nodeTransform.name;
                Offset = Vector2.zero;
                Radius = 0f;

                localPositionOnStartup = transform.localPosition;
                localEulerAnglesOnStartup = transform.localEulerAngles;
            }

            public Vector3 localPositionOnStartup;
            public Vector3 localEulerAnglesOnStartup;
        }

        /// <summary>
        /// When to gather the dynamic node information
        /// </summary>
        public BehaviorEnum Behavior = BehaviorEnum.StoreEveryTime;

        /// <summary>
        /// List of dynamic nodes in the collection
        /// </summary>
        public List<CollectionNodeDynamic> DynamicNodeList;

        [SerializeField]
        private ObjectCollection collection;

        /// <summary>
        /// Sets each node in the collection to its last stored arrangement
        /// Automatically prunes destroyed or removed nodes
        /// Does not handle nodes added since last stored arrangement
        /// </summary>
        public virtual void RestoreArrangement()
        {
            if (DynamicNodeList == null)
                return;

            for (int i = DynamicNodeList.Count - 1; i >= 0; i--)
            {
                if (DynamicNodeList[i].transform == null || DynamicNodeList[i].transform.parent != collection.transform)
                {
                    DynamicNodeList.RemoveAt(i);
                } else
                {
                    DynamicNodeList[i].transform.localPosition = DynamicNodeList[i].localPositionOnStartup;
                    DynamicNodeList[i].transform.localEulerAngles = DynamicNodeList[i].localEulerAnglesOnStartup;
                }
            }
        }

        /// <summary>
        /// Manually store collection arrangement
        /// </summary>
        public void StoreArrangement ()
        {
            if (collection == null)
                return;

            DynamicNodeList = new List<CollectionNodeDynamic>();
            if (collection.NodeList == null || collection.NodeList.Count != transform.childCount)
            {
                foreach (Transform child in transform)
                {
                    DynamicNodeList.Add(new CollectionNodeDynamic(child));
                }
            }
            else
            {
                foreach (CollectionNode node in collection.NodeList)
                {
                    DynamicNodeList.Add(new CollectionNodeDynamic(node));
                }
            }
        }

        void Awake()
        {
            if (collection == null)
            {
                collection = gameObject.GetComponent<ObjectCollection>();
            }
        }

        void Start()
        {
            switch (Behavior)
            {
                case BehaviorEnum.StoreManually:
                default:
                    // Don't do anything
                    break;

                case BehaviorEnum.StoreEveryTime:
                    // Subscribe to the collection's update events
                    collection.OnCollectionUpdated += OnCollectionUpdated;
                    break;

                case BehaviorEnum.StoreOnceOnStartup:
                    // If we're only supposed to update once
                    // Gather our list of nodes now
                    StoreArrangement();
                    break;
            }
        }

        void OnCollectionUpdated (ObjectCollection collection)
        {
            StoreArrangement();
        }
    }
}
