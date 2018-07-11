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
    /// A base class for a stabilizer that takes an input position and rotation, and performs operations on them
    /// to stabilize, or smooth deltas, in the data. 
    /// </summary>
    public abstract class BaseRayStabilizer : MonoBehaviour
    {
        /// <summary>
        /// The stabilized position.
        /// </summary>
        public abstract Vector3 StablePosition { get; }

        /// <summary>
        /// The stabilized rotation.
        /// </summary>
        public abstract Quaternion StableRotation { get; }

        /// <summary>
        /// A ray representing the stable position and rotation
        /// </summary>
        public abstract Ray StableRay { get; }

        /// <summary>
        /// Call this each frame to smooth out changes to a position and rotation, if supported.
        /// </summary>
        /// <param name="position">Input position to smooth.</param>
        /// <param name="rotation">Input rotation to smooth.</param>
        public virtual void UpdateStability(Vector3 position, Quaternion rotation)
        {
            UpdateStability(position, (rotation * Vector3.forward));
        }

        /// <summary>
        /// Call this each frame to smooth out changes to a position and direction, if supported.
        /// </summary>
        /// <param name="position">Input position to smooth.</param>
        /// <param name="direction">Input direction to smooth.</param>
        public abstract void UpdateStability(Vector3 position, Vector3 direction);
    }
}