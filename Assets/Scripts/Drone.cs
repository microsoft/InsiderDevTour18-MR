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

public class Drone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter ( Collider collider )
    {
        if (collider.gameObject.tag != "FlyingTarget")
        {
            isAtFloor = true;
            Debug.Log("collided w/ layer" + collider.gameObject.layer);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        isAtFloor = true;
        Debug.Log("collided w/ layer" + collision.collider.gameObject.layer);
    }

    public void FindFloor()
    {
        StartCoroutine(FlyUntilCollision(new Vector3(.3f, -2f, 0f), 1f));
    }

    bool isAtFloor = false;

    IEnumerator FlyUntilCollision(Vector3 offset, float speed)
    {

        isAtFloor = false; 
        Vector3 startPosition =  transform.position;
        Vector3 endPosition = startPosition + offset;

        float flyingTime = Mathf.Abs(speed * offset.y);
        float endTime = Time.time + flyingTime;
        while (isAtFloor == false && Time.time < endTime)
        {
            float progress = 1-((endTime - Time.time) / flyingTime);
            transform.position = Vector3.Slerp(startPosition, endPosition, progress);
            yield return null;
        }
    }
}
