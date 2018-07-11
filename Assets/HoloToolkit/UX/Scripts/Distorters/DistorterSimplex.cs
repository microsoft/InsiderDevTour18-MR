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
    public class DistorterSimplex : Distorter
    {
        public float ScaleMultiplier = 10f;
        public float SpeedMultiplier = 1f;
        public float StrengthMultiplier = 0.5f;
        public Vector3 AxisStrength = Vector3.one;
        public Vector3 AxisSpeed = Vector3.one;
        public Vector3 AxisOffset = Vector3.zero;
        public float ScaleDistort = 2f;
        public bool UniformScaleDistort = true;

        protected override Vector3 DistortPointInternal(Vector3 point, float strength)
        {
            Vector3 scaledPoint = (point * ScaleMultiplier) + AxisOffset;

            point.x = (float)(point.x + (noise.Evaluate(scaledPoint.x, scaledPoint.y, scaledPoint.z, Time.unscaledTime * AxisSpeed.x)) * AxisStrength.x * StrengthMultiplier);
            point.y = (float)(point.y + (noise.Evaluate(scaledPoint.x, scaledPoint.y, scaledPoint.z, Time.unscaledTime * AxisSpeed.y)) * AxisStrength.y * StrengthMultiplier);
            point.z = (float)(point.z + (noise.Evaluate(scaledPoint.x, scaledPoint.y, scaledPoint.z, Time.unscaledTime * AxisSpeed.z)) * AxisStrength.z * StrengthMultiplier);
            return point;
        }

        protected override Vector3 DistortScaleInternal(Vector3 point, float strength)
        {
            if (UniformScaleDistort)
            {
                float scale = (float)(noise.Evaluate(point.x, point.y, point.z, Time.unscaledTime));
                return Vector3.one  + (Vector3.one * (scale * ScaleDistort));
            }
            else
            {
                point = DistortPointInternal(point, strength);
                return Vector3.Lerp (Vector3.one, Vector3.Scale(Vector3.one, Vector3.one + (point * ScaleDistort)), strength);
            }
        }

        private FastSimplexNoise noise = new FastSimplexNoise();
    }
}