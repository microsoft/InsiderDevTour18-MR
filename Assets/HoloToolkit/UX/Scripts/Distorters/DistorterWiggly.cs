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
    public class DistorterWiggly : Distorter
    {
        public const float MinScaleMultiplier = 0.05f;
        public const float MaxScaleMultiplier = 1f;
        public const float MinSpeedMultiplier = -25f;
        public const float MaxSpeedMultiplier = 25f;
        public const float MinStrengthMultiplier = 0.00001f;
        public const float MaxStrengthMultiplier = 1f;

        const float GlobalScale = 0.1f;
        
        [Range(MinScaleMultiplier, MaxScaleMultiplier)]
        public float ScaleMultiplier = 0.1f;
        [Range(MinSpeedMultiplier, MaxSpeedMultiplier)]
        public float SpeedMultiplier = 3f;
        [Range(MinStrengthMultiplier, MaxStrengthMultiplier)]
        public float StrengthMultiplier = 0.01f;
        public Vector3 AxisStrength = new Vector3(0.5f, 0.1f, 0.5f);
        public Vector3 AxisSpeed = new Vector3(0.2f, 0.5f, 0.7f);
        public Vector3 AxisOffset = new Vector3(0.2f, 0.5f, 0.7f);

        protected override Vector3 DistortPointInternal(Vector3 point, float strength)
        {
            Vector3 wiggly = point;           
            float scale = ScaleMultiplier * GlobalScale;
            wiggly.x = Wiggle(AxisSpeed.x * SpeedMultiplier, (wiggly.x + AxisOffset.x) / scale, AxisStrength.x * StrengthMultiplier);
            wiggly.y = Wiggle(AxisSpeed.y * SpeedMultiplier, (wiggly.y + AxisOffset.y) / scale, AxisStrength.y * StrengthMultiplier);
            wiggly.z = Wiggle(AxisSpeed.z * SpeedMultiplier, (wiggly.z + AxisOffset.z) / scale, AxisStrength.z * StrengthMultiplier);
            return point + (wiggly * strength);
        }

        protected override Vector3 DistortScaleInternal(Vector3 point, float strength)
        {
            return point;
        }

        private float Wiggle(float speed, float offset, float strength)
        {
            return Mathf.Sin((Time.unscaledTime * speed) + offset) * strength;
        }
    }
}