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
    public abstract class Distorter : MonoBehaviour, IComparable<Distorter>
    {
        [SerializeField]
        [Range(0, 10)]
        protected int distortOrder = 0;
        [SerializeField]
        [Range(0, 1)]
        protected float distortStrength = 1f;

        public int CompareTo(Distorter other)
        {
            if (other == null) {
                return 0;
            }
            
            return DistortOrder.CompareTo(other.DistortOrder);
        }

        /// <summary>
        /// Distorts a world-space point
        /// Automatically applies DistortStrength and ensures that strength never exceeds 1
        /// </summary>
        /// <param name="point"></param>
        /// <param name="strength"></param>
        /// <returns></returns>
        public Vector3 DistortPoint (Vector3 point, float strength = 1f)
        {
            if (!isActiveAndEnabled) {
                return point;
            }

            strength = Mathf.Clamp01 (strength * DistortStrength);

            if (strength <= 0)
            {
                return point;
            }

            return DistortPointInternal(point, strength);
        }

        /// <summary>
        /// Distorts a world-space scale
        /// Automatically applies DistortStrength and ensures that strength never exceeds 1
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="strength"></param>
        /// <returns></returns>
        public Vector3 DistortScale(Vector3 scale, float strength = 1f)
        {
            if (!isActiveAndEnabled) {
                return scale;
            }

            strength = Mathf.Clamp01(strength * DistortStrength);

            return DistortScaleInternal(scale, strength);
        }

        /// <summary>
        /// Internal function where position distortion is done
        /// </summary>
        /// <param name="point"></param>
        /// <param name="strength"></param>
        /// <returns></returns>
        protected abstract Vector3 DistortPointInternal(Vector3 point, float strength);

        /// <summary>
        /// Internal function where scale distortion is done
        /// </summary>
        /// <param name="point"></param>
        /// <param name="strength"></param>
        /// <returns></returns>
        protected abstract Vector3 DistortScaleInternal(Vector3 point, float strength);

        protected virtual void OnEnable()
        {
            // Makes script enableable in editor
        }

        protected virtual void OnDisable()
        {
            // Makes script enableable in editor            
        }

        public float DistortStrength
        {
            get { return distortStrength; }
            set { distortStrength = Mathf.Clamp01(value); }
        }

        public int DistortOrder
        {
            get { return distortOrder; }
            set { distortOrder = value; } // TODO implement auto-sort
        }
    }
}