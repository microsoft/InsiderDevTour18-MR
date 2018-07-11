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

namespace HoloToolkit.Unity.UX
{
    /// <summary>
    /// Draws a bounding box gizmo in the style of the hololens shell
    /// </summary>
    [ExecuteInEditMode]
    public class BoundingBoxGizmoShell : BoundingBoxGizmo
    {
        #region public

        /// <summary>
        /// If true, bounding box edges will display when active
        /// To more closely mimic shell behavior, set this to false
        /// </summary>
        public bool DisplayEdgesWhenSelected = true;

        /// <summary>
        /// Whether to clamp handle size between HandleScaleMin / Max
        /// This may result in bunched-up handles so use with caution
        /// </summary>
        public bool ClampHandleScale = false;

        /// <summary>
        /// User-defined min size for handle
        /// Useful when using the bounding box with extremely small objects
        /// This value is ignored if ClampHandleSize is false
        /// </summary>
        public float HandleScaleMin = 0.1f;

        /// <summary>
        /// User-defined min size for handle
        /// Useful when using the bounding box with extremely large objects
        /// This value is ignored if ClampHandleSize is false
        /// </summary>
        public float HandleScaleMax = 2.0f;

        #endregion

        #region protected

        [SerializeField]
        protected Renderer edgeRenderer;

        [SerializeField]
        protected GameObject xyzHandlesObject;
        [SerializeField]
        protected GameObject xyHandlesObject;
        [SerializeField]
        protected GameObject xzHandlesObject;
        [SerializeField]
        protected GameObject zyHandlesObject;

        #endregion
    }
}