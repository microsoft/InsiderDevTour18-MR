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

        // Use this for initialization
        void Start()
        {
            
        }

        float last = 0f; 
        // Update is called once per frame
        void Update()
        {
            if (Time.time > (last + 4f))
            {
                Debug.Log(string.Format("{0} is at {1} ({2}", this.gameObject.name,
                this.transform.position, this.transform.localPosition));
            } 

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
