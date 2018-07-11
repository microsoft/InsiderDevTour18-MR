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
using UnityEngine;

namespace HoloToolkit.Unity.UX
{
    public class Bezier : LineBase
    {
        [Serializable]
        private struct PointSet
        {
            public PointSet(float spread) {
                Point1 = Vector3.right * spread * 0.5f;
                Point2 = Vector3.right * spread * 0.25f;
                Point3 = Vector3.left * spread * 0.25f;
                Point4 = Vector3.left * spread * 0.5f;
            }

            public Vector3 Point1;
            public Vector3 Point2;
            public Vector3 Point3;
            public Vector3 Point4;
        }

        [Header("Bezier Settings")]
        [SerializeField]
        private PointSet points = new PointSet(0.5f);

        public override int NumPoints {
            get {
                return 4;
            }
        }

        protected override Vector3 GetPointInternal(int pointIndex) {
            switch (pointIndex) {
                case 0:
                    return points.Point1;

                case 1:
                    return points.Point2;

                case 2:
                    return points.Point3;

                case 3:
                    return points.Point4;

                default:
                    return Vector3.zero;
            }
        }

        protected override void SetPointInternal(int pointIndex, Vector3 point) {
            switch (pointIndex) {
                case 0:
                    points.Point1 = point;
                    break;

                case 1:
                    points.Point2 = point;
                    break;

                case 2:
                    points.Point3 = point;
                    break;

                case 3:
                    points.Point4 = point;
                    break;

                default:
                    break;
            }
        }

        protected override Vector3 GetPointInternal(float normalizedDistance) {
            return LineUtils.InterpolateBezeirPoints(points.Point1, points.Point2, points.Point3, points.Point4, normalizedDistance);
        }

        protected override float GetUnclampedWorldLengthInternal() {
            // Crude approximation
            // TODO optimize
            float distance = 0f;
            Vector3 last = GetUnclampedPoint(0f);
            for (int i = 1; i < 10; i++) {
                Vector3 current = GetUnclampedPoint((float)i / 10);
                distance += Vector3.Distance(last, current);
            }
            return distance;
        }

        protected override Vector3 GetUpVectorInternal(float normalizedLength) {
            // Bezier up vectors just use transform up
            return transform.up;
        }

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Bezier))]
        public class CustomEditor : LineBaseEditor
        {
            protected override void DrawCustomSceneGUI() {
                base.DrawCustomSceneGUI();

                Bezier line = (Bezier)target;

                line.SetPoint(0, SphereMoveHandle(line.GetPoint(0)));
                line.SetPoint(1, SquareMoveHandle(line.GetPoint(1)));
                line.SetPoint(2, SquareMoveHandle(line.GetPoint(2)));
                line.SetPoint(3, SphereMoveHandle(line.GetPoint(3)));

                UnityEditor.Handles.color = handleColorTangent;
                UnityEditor.Handles.DrawLine(line.GetPoint(0), line.GetPoint(1));
                UnityEditor.Handles.DrawLine(line.GetPoint(2), line.GetPoint(3));
            }
        }
#endif
    }
}