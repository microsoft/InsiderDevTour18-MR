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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class FlyDrone : MonoBehaviour, IInputClickHandler
    {

        public GameObject flyingObject;
        public float speed = 0.7f;
        public float maxAltitude = 1.2f;

        private int stage = 0;
        private float vertOffset = 0.0238f;
        private float startY = 0.0f;
        private float endY = 0.0f;
        private Transform endpoint;
        private AudioSource sfx;

        // Use this for initialization
        void Start()
        {
            sfx = gameObject.GetComponent<AudioSource>();
        }

        float last = 0f; 
        // Update is called once per frame
        void Update()
        {            
            if (stage != 0)
            {
                // Take-off
                if (stage == 1)
                {
                    if (Mathf.Abs(flyingObject.transform.position.y - (startY + maxAltitude)) > 0.001)
                    {
                        float newY = Mathf.Min(flyingObject.transform.position.y + (Time.deltaTime * speed), startY + maxAltitude);
                        flyingObject.transform.position = new Vector3(flyingObject.transform.position.x, newY, flyingObject.transform.position.z);
                    }
                    else
                    {
                        Debug.Log("Move to stage 2");
                        stage = 2;
                    }
                        
                }
                // Move to X and Z coords
                else if (stage == 2)
                {
                    if (Mathf.Abs(flyingObject.transform.position.x - transform.position.x) > 0.001 || Mathf.Abs(flyingObject.transform.position.z - transform.position.z) > 0.001)
                    {
                        float newX; float newZ;
                        // Set new X
                        if (flyingObject.transform.position.x - transform.position.x < 0)
                            newX = Mathf.Min(flyingObject.transform.position.x + (Time.deltaTime * speed), transform.position.x);
                        else
                            newX = Mathf.Max(flyingObject.transform.position.x - (Time.deltaTime * speed), transform.position.x);
                        // Set new Z
                        if (flyingObject.transform.position.z - transform.position.z < 0)
                            newZ = Mathf.Min(flyingObject.transform.position.z + (Time.deltaTime * speed), transform.position.z);
                        else
                            newZ = Mathf.Max(flyingObject.transform.position.z - (Time.deltaTime * speed), transform.position.z);

                        flyingObject.transform.position = new Vector3(newX, flyingObject.transform.position.y, newZ);
                    }
                    else
                    {
                        Debug.Log("Move to stage 3");
                        stage = 3;
                    }
                }
                // Landing
                else if (stage == 3)
                {
                    if (Mathf.Abs(flyingObject.transform.position.y - endY) > 0.001)
                    {
                        float newY;
                        // Set new Y
                        if (flyingObject.transform.position.y - endY < 0)
                            newY = Mathf.Min(flyingObject.transform.position.y + (Time.deltaTime * speed), endY);
                        else
                            newY = Mathf.Max(flyingObject.transform.position.y - (Time.deltaTime * speed), endY);

                        flyingObject.transform.position = new Vector3(flyingObject.transform.position.x, newY, flyingObject.transform.position.z);
                    }
                    else
                    {
                        Debug.Log("Move to stage 0");
                        if (sfx != null)
                        {
                            sfx.Stop();
                        }
                        stage = 0;
                    }
                }
            }




        }

        public void StartFlying()
        {

            if (!HolographicSettings.IsDisplayOpaque)
                maxAltitude = 0.3f; 

            if (stage == 0)
            {
                startY = flyingObject.transform.position.y;
                endY = transform.position.y + vertOffset;
                stage = 1;
                if (sfx !=null)
                {
                    sfx.Play();
                }
            }
        }

        public void FindFloor ( )
        {
            StartCoroutine(FlyUntilCollision( new Vector3 ( .3f, -2f, 0f),  1f )); 
        }

        bool isAtFloor = false;  

        IEnumerator FlyUntilCollision ( Vector3 offset, float speed  )
        {
            if (flyingObject == null)
                yield break; 

            Vector3 startPosition = flyingObject.transform.position;
            Vector3 endPosition = startPosition + offset;  
            
            float flyingTime  = Mathf.Abs( speed * offset.y) ;
            float endTime = Time.time + flyingTime;
            while (isAtFloor == false && Time.time < endTime)
            {
                float progress = (endTime - Time.time) / flyingTime;
                flyingObject.transform.position = Vector3.Slerp(startPosition, endPosition, progress);
                yield return null;
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (HolographicSettings.IsDisplayOpaque)
            { 
                StartFlying();
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }


    }



}
