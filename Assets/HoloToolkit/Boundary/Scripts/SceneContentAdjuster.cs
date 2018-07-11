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

#if UNITY_2017_2_OR_NEWER
using System.Collections;
using UnityEngine.XR;
#else
using UnityEngine.VR;
#endif

namespace HoloToolkit.Unity.Boundary
{
    /// <summary>
    /// Use this script on GameObjects you wish to be aligned in certain ways depending on the application space type.
    /// For example, if you want to place an object at the height of the user's head in a room scale application, check alignWithHeadHeight.
    /// In a stationary scale application, this is equivalent to placing the object at a height of 0.
    /// You can also specify specific locations to place the object based on space type.
    /// 
    /// This script runs once, on GameObject creation.
    /// 
    /// See https://developer.microsoft.com/en-us/windows/mixed-reality/coordinate_systems_in_unity for more information.
    /// <see cref="BoundaryManager"/> for TrackingSpaceType settings.
    /// </summary>
    public class SceneContentAdjuster : MonoBehaviour
    {
        private enum AlignmentType
        {
            AlignWithHeadHeight,
            UsePresetPositions,
            UsePresetXAndZWithHeadHeight
        }

        [SerializeField]
        [Tooltip("Optional container object reference. If null, this script will move the object it's attached to.")]
        private Transform containerObject = null;

#if UNITY_2017_2_OR_NEWER
        [SerializeField]
        [Tooltip("Select this if the container should be placed in front of the head on app launch in a room scale app.")]
        private AlignmentType alignmentType = AlignmentType.AlignWithHeadHeight;

        [SerializeField]
        [Tooltip("Use this to set the desired position of the container in a stationary app. This will be ignored if AlignWithHeadHeight is set.")]
        private Vector3 stationarySpaceTypePosition = Vector3.zero;

        [SerializeField]
        [Tooltip("Use this to set the desired position of the container in a room scale app. This will be ignored if AlignWithHeadHeight is set.")]
        private Vector3 roomScaleSpaceTypePosition = Vector3.zero;

        private Vector3 contentPosition = Vector3.zero;

        private int frameWaitHack = 0;
#endif

        private void Awake()
        {
            if (containerObject == null)
            {
                containerObject = transform;
            }

#if UNITY_2017_2_OR_NEWER
            // If no XR device is present, the editor will default to (0, 0, 0) and no adjustment is needed.
            // This script runs on both opaque and transparent display devices, since the floor offset is based on
            // TrackingSpaceType and not display type.
            if (XRDevice.isPresent)
            {
                StartCoroutine(SetContentHeight());
                return;
            }
#endif
            Destroy(this);
        }

#if UNITY_2017_2_OR_NEWER
        private IEnumerator SetContentHeight()
        {
            if (frameWaitHack < 1)
            {
                // Not waiting a frame often caused the camera's position to be incorrect at this point. This seems like a Unity bug.
                frameWaitHack++;
                yield return null;
            }

            if (alignmentType == AlignmentType.UsePresetPositions || alignmentType == AlignmentType.UsePresetXAndZWithHeadHeight)
            {
                if (XRDevice.GetTrackingSpaceType() == TrackingSpaceType.RoomScale)
                {
                    containerObject.position = roomScaleSpaceTypePosition;
                }
                else if (XRDevice.GetTrackingSpaceType() == TrackingSpaceType.Stationary)
                {
                    containerObject.position = stationarySpaceTypePosition;
                }
            }

            if (alignmentType == AlignmentType.AlignWithHeadHeight || alignmentType == AlignmentType.UsePresetXAndZWithHeadHeight)
            {
                contentPosition.x = containerObject.position.x;
                contentPosition.y = containerObject.position.y + CameraCache.Main.transform.position.y;
                contentPosition.z = containerObject.position.z;

                containerObject.position = contentPosition;
            }
        }
#endif
    }
}
