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
    public class Ellipse : LineBase
    {
        const int MaxPoints = 2048;

        [Header ("Ellipse Settings")]
        public int Resolution = 36;
        public Vector2 Radius = new Vector2(1f, 1f);

        public override int NumPoints
        {
            get
            {
                Resolution = Mathf.Clamp(Resolution, 0, MaxPoints);
                return Resolution;
            }
        }

        protected override Vector3 GetPointInternal(float normalizedDistance)
        {
            return LineUtils.GetEllipsePoint(Radius.x, Radius.y, normalizedDistance * 2f * Mathf.PI);
        }

        protected override Vector3 GetPointInternal(int pointIndex)
        {
            float angle = ((float)pointIndex / Resolution) * 2f * Mathf.PI;
            return LineUtils.GetEllipsePoint(Radius.x, Radius.y, angle);
        }

        protected override void SetPointInternal(int pointIndex, Vector3 point)
        {
            // Does nothing for an ellipse
            return;
        }

        protected override float GetUnclampedWorldLengthInternal()
        {
            // Crude approximation
            // TODO optimize
            float distance = 0f;
            Vector3 last = GetUnclampedPoint(0f);
            for (int i = 1; i < 10; i++)
            {
                Vector3 current = GetUnclampedPoint((float)i / 10);
                distance += Vector3.Distance(last, current);
            }
            return distance;
        }

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Ellipse))]
        public class CustomEditor : LineBaseEditor { }
#endif
    }
}