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
    /// Class for manually controlling the camera when not running on HoloLens (in editor). 
    /// Attach to same main camera game object.
    /// </summary>
    public class ManualGazeControl : MonoBehaviour
    {
        public bool MouseSupported = true;
        public AxisController MouseXYRotationAxisControl;
        public AxisController MouseXYTranslationAxisControl;
        public AxisController MouseXZTranslationAxisControl;

        public bool KeyboardSupported = true;
        public AxisController KeyboardXYRotationAxisControl;
        public AxisController KeyboardXZRotationAxisControl;
        public AxisController KeyboardXYTranslationAxisControl;
        public AxisController KeyboardXZTranslationAxisControl;

        public bool JoystickSupported = false;
        public AxisController JoystickXYRotationAxisControl;
        public AxisController JoystickXYTranslationAxisControl;
        public AxisController JoystickXZTranslationAxisControl;

        private Vector3 lastTrackerToUnityTranslation = Vector3.zero;
        private Quaternion lastTrackerToUnityRotation = Quaternion.identity;

        private Transform cameraTransform;

        private void Awake()
        {
            if (Application.isEditor)
            {

#if UNITY_2017_2_OR_NEWER
                if (UnityEngine.XR.XRDevice.isPresent)
#else
                if (UnityEngine.VR.VRDevice.isPresent)
#endif
                {
                    Destroy(this);
                    return;
                }
            }
            else
            {
                Destroy(this);
                return;
            }

            cameraTransform = GetComponent<Camera>().transform;
            if (cameraTransform == null)
            {
                Debug.LogError("ManualGazeControl being used on a game object without a Camera.");
            }

            MouseXYRotationAxisControl.enabled = MouseSupported;
            MouseXYTranslationAxisControl.enabled = MouseSupported;
            MouseXZTranslationAxisControl.enabled = MouseSupported;

            KeyboardXYRotationAxisControl.enabled = KeyboardSupported;
            KeyboardXZRotationAxisControl.enabled = KeyboardSupported;
            KeyboardXYTranslationAxisControl.enabled = KeyboardSupported;
            KeyboardXZTranslationAxisControl.enabled = KeyboardSupported;

            JoystickXYRotationAxisControl.enabled = JoystickSupported;
            JoystickXYTranslationAxisControl.enabled = JoystickSupported;
            JoystickXZTranslationAxisControl.enabled = JoystickSupported;
        }

        private void Update()
        {
            // Undo the last tracker to Unity transforms applied.
            cameraTransform.Translate(-this.lastTrackerToUnityTranslation, Space.World);
            cameraTransform.Rotate(-this.lastTrackerToUnityRotation.eulerAngles, Space.World);

            // Undo the last local Z-axis tilt rotation.
            float previousZTilt = this.transform.localEulerAngles.z;
            cameraTransform.Rotate(0, 0, -previousZTilt, Space.Self);

            // Calculate and apply the camera control movement this frame
            Vector3 rotate = Vector3.zero;
            Vector3 translate = Vector3.zero;

            if (MouseSupported)
            {
                Vector3 mouseXYRotate = MouseXYRotationAxisControl.GetDisplacementVector3();
                Vector3 mouseXYTranslate = MouseXYTranslationAxisControl.GetDisplacementVector3();
                Vector3 mouseXZTranslate = MouseXZTranslationAxisControl.GetDisplacementVector3();
                rotate += mouseXYRotate;
                translate += mouseXYTranslate;
                translate += mouseXZTranslate;
            }

            if (KeyboardSupported)
            {
                Vector3 keyboardXYRotate = KeyboardXYRotationAxisControl.GetDisplacementVector3();
                Vector3 keyboardXZRotate = KeyboardXZRotationAxisControl.GetDisplacementVector3();
                Vector3 keyboardXYTranslate = KeyboardXYTranslationAxisControl.GetDisplacementVector3();
                Vector3 keyboardXZTranslate = KeyboardXZTranslationAxisControl.GetDisplacementVector3();
                rotate += keyboardXYRotate;
                rotate += keyboardXZRotate;
                translate += keyboardXYTranslate;
                translate += keyboardXZTranslate;
            }

            if (JoystickSupported)
            {
                Vector3 joystickXYRotate = JoystickXYRotationAxisControl.GetDisplacementVector3();
                Vector3 joystickXYTranslate = JoystickXYTranslationAxisControl.GetDisplacementVector3();
                Vector3 joystickXZTranslate = JoystickXZTranslationAxisControl.GetDisplacementVector3();
                rotate += joystickXYRotate;
                translate += joystickXYTranslate;
                translate += joystickXZTranslate;
            }

            rotate *= Mathf.Rad2Deg;    // change to degrees for the Rotate function

            // Now apply the displacements to the camera
            cameraTransform.Rotate(rotate.x, 0.0f, 0.0f, Space.Self);
            cameraTransform.Rotate(0.0f, rotate.y, 0.0f, Space.World);
            cameraTransform.Translate(translate, Space.Self);

            // Apply updated local Z-axis tilt rotation.
            cameraTransform.Rotate(0.0f, 0.0f, rotate.z + previousZTilt, Space.Self);

            // Re-apply the last tracker to Unity transform.
            cameraTransform.Rotate(this.lastTrackerToUnityRotation.eulerAngles, Space.World);
            cameraTransform.Translate(this.lastTrackerToUnityTranslation, Space.World);
        }
    }
}
