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
    public class DistorterBulge : Distorter
    {
        public Vector3 BulgeCenter
        {
            get
            {
                return transform.TransformPoint(bulgeCenter);
            }
            set
            {
                bulgeCenter = transform.InverseTransformPoint(value);
            }
        }

        [SerializeField]
        private Vector3 bulgeCenter = Vector3.zero;
        [SerializeField]
        private AnimationCurve bulgeFalloff = new AnimationCurve();
        [SerializeField]
        private float bulgeRadius = 1f;
        [SerializeField]
        private float scaleDistort = 2f;
        [SerializeField]
        private float bulgeStrength = 1f;

        protected override Vector3 DistortPointInternal (Vector3 point, float strength)
        {
            float distanceToCenter = Vector3.Distance(point, BulgeCenter);
            if (distanceToCenter < bulgeRadius)
            {
                float distortion = (1f - (bulgeFalloff.Evaluate(distanceToCenter / bulgeRadius))) * bulgeStrength;
                Vector3 direction = (point - BulgeCenter).normalized;
                point = point + (direction * distortion * bulgeStrength);
            }
            return point;
        }

        protected override Vector3 DistortScaleInternal(Vector3 point, float strength)
        {
            float distanceToCenter = Vector3.Distance(point, BulgeCenter);
            if (distanceToCenter < bulgeRadius)
            {
                float distortion = (1f - (bulgeFalloff.Evaluate(distanceToCenter / bulgeRadius))) * bulgeStrength;
                return Vector3.one + (Vector3.one * distortion * scaleDistort);
            }
            return Vector3.one;
        }

        private void OnDrawGizmos()
        {
            Vector3 bulgePoint = transform.TransformPoint(bulgeCenter);
            Color gColor = Color.red;
            gColor.a = 0.5f;
            Gizmos.color = gColor;
            Gizmos.DrawWireSphere(bulgePoint, bulgeRadius);
            int steps = 8;
            for (int i = 0; i < steps; i++)
            {
                float normalizedStep = (1f / steps) * i;
                gColor.a = (1f - bulgeFalloff.Evaluate(normalizedStep)) * 0.5f;
                Gizmos.color = gColor;
                Gizmos.DrawSphere(bulgePoint, bulgeRadius * bulgeFalloff.Evaluate(normalizedStep));
            }
        }
    }
}
