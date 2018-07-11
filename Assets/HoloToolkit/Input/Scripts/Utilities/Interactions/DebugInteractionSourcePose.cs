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

namespace HoloToolkit.Unity.InputModule
{
    /// <summary>
    /// Since the InteractionSourcePose is internal to UnityEngine.VR.WSA.Input,
    /// this is a fake InteractionSourcePose structure to keep the test code consistent.
    /// </summary>
    public class DebugInteractionSourcePose
    {
        /// <summary>
        /// In the typical InteractionSourcePose, the hardware determines if
        /// TryGetPosition and TryGetVelocity will return true or not. Here
        /// we manually emulate this state with TryGetFunctionsReturnTrue.
        /// </summary>
        public bool TryGetFunctionsReturnTrue;
        public bool IsPositionAvailable;
        public bool IsRotationAvailable;

        public Vector3 Position;
        public Vector3 Velocity;
        public Quaternion Rotation;
        public Ray? PointerRay;

        public DebugInteractionSourcePose()
        {
            TryGetFunctionsReturnTrue = false;
            IsPositionAvailable = false;
            IsRotationAvailable = false;
            Position = new Vector3(0, 0, 0);
            Velocity = new Vector3(0, 0, 0);
            Rotation = Quaternion.identity;
        }

        public bool TryGetPosition(out Vector3 position)
        {
            position = Position;
            if (!TryGetFunctionsReturnTrue)
            {
                return false;
            }
            return true;
        }

        public bool TryGetVelocity(out Vector3 velocity)
        {
            velocity = Velocity;
            if (!TryGetFunctionsReturnTrue)
            {
                return false;
            }
            return true;
        }

        public bool TryGetRotation(out Quaternion rotation)
        {
            rotation = Rotation;
            if (!TryGetFunctionsReturnTrue || !IsRotationAvailable)
            {
                return false;
            }
            return true;
        }

        public bool TryGetPointerRay(out Ray pointerRay)
        {
            pointerRay = (Ray)PointerRay;
            if (PointerRay == null)
            {
                return false;
            }
            return true;
        }
    }
}