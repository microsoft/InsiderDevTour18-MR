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

namespace HoloToolkit.UI.Keyboard
{
    /// <summary>
    /// Axis slider is a script to lock a bar across a specific axis.
    /// </summary>
    public class AxisSlider : MonoBehaviour
    {

        public enum EAxis
        {
            X,
            Y,
            Z
        }

        public EAxis Axis = EAxis.X;

        private float currentPos;
        private float slideVel;

        public float slideAccel = 5.25f;
        public float slideFriction = 6f;
        public float deadZone = 0.55f;
        public float clampDistance = 300.0f;
        public float bounce = 0.5f;

        [HideInInspector]
        public Vector3 TargetPoint;

        private float GetAxis(Vector3 v)
        {
            switch (Axis)
            {
                case EAxis.X: return v.x;
                case EAxis.Y: return v.y;
                case EAxis.Z: return v.z;
            }
            return 0;
        }

        private Vector3 SetAxis(Vector3 v, float f)
        {
            switch (Axis)
            {
                case EAxis.X: v.x = f; break;
                case EAxis.Y: v.y = f; break;
                case EAxis.Z: v.z = f; break;
            }
            return v;
        }

        /// <summary>
        /// Use late update to track the input slider
        /// </summary>
        private void LateUpdate()
        {
            float targetP = GetAxis(TargetPoint);

            float dt = Time.deltaTime;
            float delta = targetP - currentPos;

            // Accelerate left or right if outside of deadzone
            if (Mathf.Abs(delta) > deadZone * deadZone)
            {
                slideVel += slideAccel * Mathf.Sign(delta) * dt;
            }

            // Apply friction
            slideVel -= slideVel * slideFriction * dt;

            // Apply velocity to position
            currentPos += slideVel * dt;

            // Clamp to sides (bounce)
            if (Mathf.Abs(currentPos) >= clampDistance)
            {
                slideVel *= -bounce;
                currentPos = clampDistance * Mathf.Sign(currentPos);
            }

            // Set position
            transform.localPosition = SetAxis(transform.localPosition, currentPos);
        }
    }
}
