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
    public class DistorterGravity : Distorter
    {
        public Vector3 WorldCenterOfGravity
        {
            get
            {
                return transform.TransformPoint(LocalCenterOfGravity);
            }
            set
            {
                LocalCenterOfGravity = transform.InverseTransformPoint(value);
            }
        }

        public Vector3 LocalCenterOfGravity;
        public Vector3 AxisStrength = Vector3.one;
        [Range(0f, 10f)]
        public float Radius = 0.5f;
        public AnimationCurve GravityStrength = AnimationCurve.EaseInOut(0, 0, 1, 1);
        
        protected override Vector3 DistortPointInternal(Vector3 point, float strength)
        {
            Vector3 target = WorldCenterOfGravity;

            float normalizedDistance = 1f - Mathf.Clamp01 (Vector3.Distance(point, target) / Radius);

            strength *= GravityStrength.Evaluate (normalizedDistance);

            point.x = Mathf.Lerp(point.x, target.x, Mathf.Clamp01(strength * AxisStrength.x));
            point.y = Mathf.Lerp(point.y, target.y, Mathf.Clamp01(strength * AxisStrength.y));
            point.z = Mathf.Lerp(point.z, target.z, Mathf.Clamp01(strength * AxisStrength.z));

            return point;
        }

        protected override Vector3 DistortScaleInternal(Vector3 point, float strength)
        {
            return point;
        }

        public void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(WorldCenterOfGravity, 0.05f);
            Gizmos.DrawWireSphere(WorldCenterOfGravity, Radius);
        }
    }
}