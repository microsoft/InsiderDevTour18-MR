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

//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

namespace HoloToolkit.Unity.InputModule
{
    /// <summary>
    /// CameraMotionInfo calculates the velocity and direction of the camera. 
    /// </summary>
    public class CameraMotionInfo : Singleton<CameraMotionInfo>
    {
        #region Public accessors
        public Vector3 HeadVelocity { get { return headVelocity; } }
        public Vector3 MoveDirection { get { return headMoveDirection; } }

        [Tooltip("Minimum velicoty threshold")]
        public float headVelIdleThresh = 0.5f;
        [Tooltip("Maximum velicoty threshold")]
        public float headVelMoveThresh = 2f;
        #endregion

        #region Private members
        private Vector3 headVelocity;
        private Vector3 lastHeadPos;
        private Vector3 newHeadMoveDirection;
        private Vector3 headMoveDirection = Vector3.one;

        [SerializeField]
        private bool debugDrawHeadVelocity = true;
        [SerializeField]
        private bool debugDrawHeadDirection = true;
        #endregion

        private void FixedUpdate()
        {
            // Update headVelocity
            Vector3 newHeadPos = CameraCache.Main.transform.position;
            Vector3 headDelta = newHeadPos - lastHeadPos;

            float moveThreshold = 0.01f;
            if (headDelta.sqrMagnitude < moveThreshold * moveThreshold)
            {
                headDelta = Vector3.zero;
            }

            if (Time.fixedDeltaTime > 0)
            {
                float velAdjustRate = 3f * Time.fixedDeltaTime;
                headVelocity = headVelocity * (1f - velAdjustRate) + headDelta * velAdjustRate / Time.fixedDeltaTime;

                float velThreshold = .1f;
                if (headVelocity.sqrMagnitude < velThreshold * velThreshold)
                {
                    headVelocity = Vector3.zero;
                }
            }

            // Update headDirection
            float velP = Mathf.Clamp01(Mathf.InverseLerp(headVelIdleThresh, headVelMoveThresh, headVelocity.magnitude));

            newHeadMoveDirection = Vector3.Lerp(newHeadPos, headVelocity, velP).normalized;
            lastHeadPos = newHeadPos;
            float dirAdjustRate = Mathf.Clamp01(5f * Time.fixedDeltaTime);

            headMoveDirection = Vector3.Slerp(headMoveDirection, newHeadMoveDirection, dirAdjustRate);

            if(debugDrawHeadDirection)
            {
                Debug.DrawLine(lastHeadPos, lastHeadPos + headMoveDirection * 10f, Color.Lerp(Color.red, Color.green, velP));
            }

            if(debugDrawHeadVelocity)
            {
                Debug.DrawLine(lastHeadPos, lastHeadPos + headVelocity, Color.yellow);
            }
        }
    }
}