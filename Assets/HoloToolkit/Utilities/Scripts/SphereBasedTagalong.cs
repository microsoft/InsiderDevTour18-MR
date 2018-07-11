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

namespace HoloToolkit.Unity
{
    /// <summary>
    /// A Tagalong that stays at a fixed distance from the camera and always
    /// seeks to stay on the edge or inside a sphere that is straight in front of the camera.
    /// </summary>
    public class SphereBasedTagalong : MonoBehaviour
    {
        [Tooltip("Sphere radius.")]
        public float SphereRadius = 1.0f;

        [Tooltip("How fast the object will move to the target position.")]
        public float MoveSpeed = 2.0f;

        /// <summary>
        /// When moving, use unscaled time. This is useful for games that have a pause mechanism or otherwise adjust the game timescale.
        /// </summary>
        [SerializeField]
        [Tooltip("When moving, use unscaled time. This is useful for games that have a pause mechanism or otherwise adjust the game timescale.")]
        private bool useUnscaledTime = true;

        /// <summary>
        /// Used to initialize the initial position of the SphereBasedTagalong before being hidden on LateUpdate.
        /// </summary>
        [SerializeField]
        [Tooltip("Used to initialize the initial position of the SphereBasedTagalong before being hidden on LateUpdate.")]
        private bool hideOnStart;

        [SerializeField]
        [Tooltip("Display the sphere in red wireframe for debugging purposes.")]
        private bool debugDisplaySphere = false;

        [SerializeField]
        [Tooltip("Display a small green cube where the target position is.")]
        private bool debugDisplayTargetPosition = false;

        private Vector3 targetPosition;
        private Vector3 optimalPosition;
        private float initialDistanceToCamera;

        private void Start()
        {
            initialDistanceToCamera = Vector3.Distance(transform.position, CameraCache.Main.transform.position);
        }

        private void Update()
        {
            optimalPosition = CameraCache.Main.transform.position + CameraCache.Main.transform.forward * initialDistanceToCamera;
            Vector3 offsetDir = transform.position - optimalPosition;

            if (offsetDir.magnitude > SphereRadius)
            {
                targetPosition = optimalPosition + offsetDir.normalized * SphereRadius;

                float deltaTime = useUnscaledTime
                    ? Time.unscaledDeltaTime
                    : Time.deltaTime;

                transform.position = Vector3.Lerp(transform.position, targetPosition, MoveSpeed * deltaTime);
            }
        }

        private void LateUpdate()
        {
            if (hideOnStart)
            {
                hideOnStart = !hideOnStart;
                gameObject.SetActive(false);
            }
        }

        public void OnDrawGizmos()
        {
            if (Application.isPlaying == false) { return; }

            Color oldColor = Gizmos.color;

            if (debugDisplaySphere)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(optimalPosition, SphereRadius);
            }

            if (debugDisplayTargetPosition)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawCube(targetPosition, new Vector3(0.1f, 0.1f, 0.1f));
            }

            Gizmos.color = oldColor;
        }
    }
}
