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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.UX
{
    public class DistorterSphere : Distorter
    {
        public Vector3 SphereCenter
        {
            get
            {
                return transform.TransformPoint(sphereCenter);
            }
            set
            {
                sphereCenter = transform.InverseTransformPoint(value);
            }
        }

        [SerializeField]
        private Vector3 sphereCenter;
        [SerializeField]
        private float radius = 2f;

        protected override Vector3 DistortPointInternal(Vector3 point, float strength)
        {
            Vector3 direction = (point - SphereCenter).normalized;
            return Vector3.Lerp(point, SphereCenter + (direction * radius), strength);
        }

        protected override Vector3 DistortScaleInternal(Vector3 point, float strength)
        {
            return Vector3.one;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(SphereCenter, radius);
        }
    }
}