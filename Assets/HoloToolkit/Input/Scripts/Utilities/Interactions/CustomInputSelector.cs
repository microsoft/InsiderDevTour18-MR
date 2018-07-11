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
using System.Collections.Generic;
using UnityEngine;
#if UNITY_2017_2_OR_NEWER
using UnityEngine.XR;
#else
using UnityEngine.VR;
#endif

namespace HoloToolkit.Unity.InputModule
{
    /// <summary>
    /// This class is used to select input for the Editor and applications built outside of the UWP build target.
    /// </summary>
    public class CustomInputSelector : MonoBehaviour
    {
        private enum InputSourceType
        {
            Hand,
            Mouse
        }

        private enum InputSourceNumber
        {
            One,
            Two
        }

        [SerializeField]
        private bool simulateHandsInEditor = true;

        [SerializeField]
        private InputSourceType sourceType;

        [SerializeField]
        private InputSourceNumber sourceNumber;

        public List<GameObject> Inputs = new List<GameObject>(0);

        [SerializeField]
        private GameObject mouse = null;

        [SerializeField]
        private GameObject leftHand = null;

        [SerializeField]
        private GameObject rightHand = null;

        private void Awake()
        {
            bool spawnControllers = false;

#if UNITY_2017_2_OR_NEWER
            spawnControllers = !XRDevice.isPresent && XRSettings.enabled && simulateHandsInEditor;
#else
            spawnControllers = simulateHandsInEditor;
#endif
            if (spawnControllers)
            {
                sourceType = InputSourceType.Hand;
                sourceNumber = InputSourceNumber.Two;
            }

            if (!spawnControllers) { return; }

            switch (sourceType)
            {
                case InputSourceType.Hand:
                    GameObject newRightInputSource = Instantiate(rightHand);

                    newRightInputSource.name = "Right_" + sourceType.ToString();
                    newRightInputSource.transform.SetParent(transform);
                    Inputs.Add(newRightInputSource);

                    if (sourceNumber == InputSourceNumber.Two)
                    {
                        GameObject newLeftInputSource = Instantiate(leftHand);
                        newLeftInputSource.name = "Left_" + sourceType.ToString();
                        newLeftInputSource.transform.SetParent(transform);
                        Inputs.Add(newLeftInputSource);
                    }
                    break;
                case InputSourceType.Mouse:
                    GameObject newMouseInputSource = Instantiate(mouse);
                    newMouseInputSource.transform.SetParent(transform);
                    Inputs.Add(newMouseInputSource);

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
