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

using HoloToolkit.Unity;
using UnityEngine;

namespace HoloToolkit.Unity.UX
{
    public class Line : LineBase
    {
        [Header("Line Settings")]
        public Vector3 Start = Vector3.zero;
        public Vector3 End = Vector3.one;

        public override int NumPoints
        {
            get
            {
                return 2;
            }
        }

        protected override Vector3 GetPointInternal(int pointIndex)
        {
            switch (pointIndex)
            {
                case 0:
                default:
                    return Start;

                case 1:
                    return End;
            }
        }

        protected override void SetPointInternal(int pointIndex, Vector3 point)
        {
            switch (pointIndex)
            {
                case 0:
                default:
                    Start = point;
                    break;

                case 1:
                    End = point;
                    break;
            }
        }

        protected override Vector3 GetPointInternal(float normalizedDistance)
        {
            return Vector3.Lerp(Start, End, normalizedDistance);
        }

        protected override float GetUnclampedWorldLengthInternal()
        {
            return Vector3.Distance(Start, End);
        }

        protected override Vector3 GetUpVectorInternal(float normalizedLength)
        {
            return transform.up;
        }

#if UNITY_EDITOR
        [UnityEditor.CustomEditor(typeof(Line))]
        public class CustomEditor : LineBaseEditor {
            protected override void DrawCustomSceneGUI()
            {
                base.DrawCustomSceneGUI();

                LineBase line = (LineBase)target;
                line.FirstPoint = SquareMoveHandle(line.FirstPoint);
                line.LastPoint = SquareMoveHandle(line.LastPoint);
            }
        }
#endif
    }
}