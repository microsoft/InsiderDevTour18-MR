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
using System;
using System.Collections;
using HoloToolkit.Unity;

namespace HoloToolkit.Unity.Buttons
{
    /// <summary>
    /// Prefab button has a set of prefabs of linked objects created or linked to the different states.  Simply reference
    /// the prefab object or the instanced game object to the state and it will be toggled active or inactive based on the
    /// current state.
    /// </summary>
    public class ObjectButton : Button
    {
        /// <summary>
        /// Object Button State Data Set
        /// </summary>
        [Serializable]
        public class ObjectButtonDatum
        {
            /// <summary>
            /// Constructor for prefab datum
            /// </summary>
            public ObjectButtonDatum(ButtonStateEnum state) { this.ActiveState = state; this.Name = state.ToString(); }

            /// <summary>
            /// Name of Datum entry
            /// </summary>
            public string Name;
            /// <summary>
            /// Button State association
            /// </summary>
            public ButtonStateEnum ActiveState;
            /// <summary>
            /// Button prefab for new state
            /// </summary>
            public GameObject Prefab;
            /// <summary>
            /// Spawned instance from the prefab
            /// </summary>
            [HideInInspector]
            public GameObject Instance;
            /// <summary>
            /// Offset to translate prefab to in active state
            /// </summary>
            public Vector3 Offset;
            /// <summary>
            /// New scale for prefab in button state
            /// </summary>
            public Vector3 Scale = Vector3.one;
        }

        /// <summary>
        /// Button State data set for different interaction states
        /// </summary>
        [Header("Game Object Button")]
        [Tooltip("Button State information")]
        public ObjectButtonDatum[] ButtonStates = new ObjectButtonDatum[]{ new ObjectButtonDatum((ButtonStateEnum)0),
            new ObjectButtonDatum((ButtonStateEnum)1), new ObjectButtonDatum((ButtonStateEnum)2), new ObjectButtonDatum((ButtonStateEnum)3),
            new ObjectButtonDatum((ButtonStateEnum)4), new ObjectButtonDatum((ButtonStateEnum)5) };

        /// <summary>
        /// On start create all the instances if the referenced object is a prefab 
        /// </summary>
        protected void Start()
        {
            for (int i = 0; i < ButtonStates.Length; i++)
            {
                if(ButtonStates[i].Prefab != null)
                {
                    if(ButtonStates[i].Prefab.scene.IsValid())
                    {
                        ButtonStates[i].Instance = Instantiate(ButtonStates[i].Prefab, this.transform.position, this.transform.rotation) as GameObject;
                        ButtonStates[i].Instance.transform.parent = this.transform;

                        // Remove Clone Name
                        ButtonStates[i].Instance.name = ButtonStates[i].Instance.name.Substring(0, ButtonStates[i].Instance.name.Length - 7);
                    }
                    else
                    {
                        ButtonStates[i].Instance = ButtonStates[i].Prefab;
                    }

                    ButtonStates[i].Instance.transform.localScale = Vector3.Scale(ButtonStates[i].Instance.transform.localScale, ButtonStates[i].Scale);
                    ButtonStates[i].Instance.transform.localPosition = ButtonStates[i].Instance.transform.localPosition + ButtonStates[i].Offset;

                    // Now set inactive till state change
                    ButtonStates[i].Instance.SetActive(false);
                }

                OnStateChange(ButtonStateEnum.Observation);
            }
        }

        /// <summary>
        /// Callback override function to change prefab enabled on button state change
        /// </summary>
        /// <param name="newState">
        /// A <see cref="ButtonStateEnum"/> for the new button state.
        /// </param>
        public override void OnStateChange(ButtonStateEnum newState)
        {
            for (int i = 0; i < ButtonStates.Length; i++)
            {
                if(ButtonStates[i].Instance != null)
                {
                    ButtonStates[i].Instance.SetActive(i == (int)newState);
                }
            }

            base.OnStateChange(newState);
        }
    }
}