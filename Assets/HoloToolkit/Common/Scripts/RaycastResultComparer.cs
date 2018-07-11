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
using UnityEngine.EventSystems;

namespace HoloToolkit.Unity
{
    public struct ComparableRaycastResult
    {
        public readonly int LayerMaskIndex;
        public readonly RaycastResult RaycastResult;

        public ComparableRaycastResult(RaycastResult raycastResult, int layerMaskIndex = 0)
        {
            RaycastResult = raycastResult;
            LayerMaskIndex = layerMaskIndex;
        }
    }

    public class RaycastResultComparer : IComparer<ComparableRaycastResult>
    {
        private static readonly List<Func<ComparableRaycastResult, ComparableRaycastResult, int>> Comparers = new List<Func<ComparableRaycastResult, ComparableRaycastResult, int>>
        {
            CompareRaycastsByLayerMaskPrioritization,
            CompareRaycastsBySortingLayer,
            CompareRaycastsBySortingOrder,
            CompareRaycastsByCanvasDepth,
            CompareRaycastsByDistance,
        };

        public int Compare(ComparableRaycastResult left, ComparableRaycastResult right)
        {
            for (var i = 0; i < Comparers.Count; i++)
            {
                var result = Comparers[i](left, right);
                if (result != 0)
                {
                    return result;
                }
            }
            return 0;
        }

        private static int CompareRaycastsByLayerMaskPrioritization(ComparableRaycastResult left, ComparableRaycastResult right)
        {
            //Lower is better, -1 is not relevant
            return right.LayerMaskIndex.CompareTo(left.LayerMaskIndex);
        }

        private static int CompareRaycastsBySortingLayer(ComparableRaycastResult left, ComparableRaycastResult right)
        {
            //Higher is better
            return left.RaycastResult.sortingLayer.CompareTo(right.RaycastResult.sortingLayer);
        }

        private static int CompareRaycastsBySortingOrder(ComparableRaycastResult left, ComparableRaycastResult right)
        {
            //Higher is better
            return left.RaycastResult.sortingOrder.CompareTo(right.RaycastResult.sortingOrder);
        }

        private static int CompareRaycastsByCanvasDepth(ComparableRaycastResult left, ComparableRaycastResult right)
        {
            //Module is the graphic raycaster on the canvases.
            if (left.RaycastResult.module.transform.IsParentOrChildOf(right.RaycastResult.module.transform))
            {
                //Higher is better
                return left.RaycastResult.depth.CompareTo(right.RaycastResult.depth);
            }
            return 0;
        }

        private static int CompareRaycastsByDistance(ComparableRaycastResult left, ComparableRaycastResult right)
        {
            //Lower is better
            return right.RaycastResult.distance.CompareTo(left.RaycastResult.distance);
        }
    }
}
