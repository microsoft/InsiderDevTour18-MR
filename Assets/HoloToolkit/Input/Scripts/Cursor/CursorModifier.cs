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
    /// Component that can be added to any game object with a collider to modify 
    /// how a cursor reacts when on that collider.
    /// </summary>
    public class CursorModifier : MonoBehaviour, ICursorModifier
    {
        [Tooltip("Transform for which this cursor modifier applies its various properties.")]
        public Transform HostTransform;

        [Tooltip("How much a cursor should be offset from the surface of the object when overlapping.")]
        public Vector3 CursorOffset = Vector3.zero;

        [Tooltip("Direction of the cursor offset.")]
        public Vector3 CursorNormal = Vector3.back;

        [Tooltip("Scale of the cursor when looking at this object.")]
        public Vector3 CursorScaleOffset = Vector3.one;

        [Tooltip("Should the cursor snap to the object.")]
        public bool SnapCursor = false;

        [Tooltip("If true, the normal from the pointing vector will be used to orient the cursor " +
                 "instead of the targeted object's normal at point of contact.")]
        public bool UseGazeBasedNormal = false;

        [Tooltip("Should the cursor be hiding when this object is focused.")]
        public bool HideCursorOnFocus = false;

        [Tooltip("Cursor animation parameters to set when this object is focused. Leave empty for none.")]
        public AnimatorParameter[] CursorParameters;

        private void Awake()
        {
            if (HostTransform == null)
            {
                HostTransform = transform;
            }
        }

        /// <summary>
        /// Return whether or not hide the cursor
        /// </summary>
        /// <returns></returns>
        public bool GetCursorVisibility()
        {
            return HideCursorOnFocus;
        }

        public Vector3 GetModifiedPosition(ICursor cursor)
        {
            Vector3 position;

            if (SnapCursor)
            {
                // Snap if the targeted object has a cursor modifier that supports snapping
                position = HostTransform.position +
                           HostTransform.TransformVector(CursorOffset);
            }
            else
            {
                FocusDetails focusDetails = FocusManager.Instance.GetFocusDetails(cursor.Pointer);

                // Else, consider the modifiers on the cursor modifier, but don't snap
                position = focusDetails.Point + HostTransform.TransformVector(CursorOffset);
            }

            return position;
        }

        public Quaternion GetModifiedRotation(ICursor cursor)
        {
            Quaternion rotation;

            RayStep lastStep = cursor.Pointer.Rays[cursor.Pointer.Rays.Length - 1];
            Vector3 forward = UseGazeBasedNormal ? -lastStep.Direction : HostTransform.rotation * CursorNormal;

            // Determine the cursor forward
            if (forward.magnitude > 0)
            {
                rotation = Quaternion.LookRotation(forward, Vector3.up);
            }
            else
            {
                rotation = cursor.Rotation;
            }

            return rotation;
        }

        public Vector3 GetModifiedScale(ICursor cursor)
        {
            return CursorScaleOffset;
        }

        public void GetModifiedTransform(ICursor cursor, out Vector3 position, out Quaternion rotation, out Vector3 scale)
        {
            position = GetModifiedPosition(cursor);
            rotation = GetModifiedRotation(cursor);
            scale = GetModifiedScale(cursor);
        }
    }
}
