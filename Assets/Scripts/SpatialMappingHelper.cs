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

[RequireComponent(typeof(SpatialMappingCollider))]
[RequireComponent(typeof(SpatialMappingRenderer))]
public class SpatialMappingHelper : MonoBehaviour {

    SpatialMappingRenderer mappingRenderer;
    SpatialMappingCollider mappingCollider;

    [SerializeField]
    bool autoStart = false;

    [SerializeField]
    bool collideWhenNotRendering = true; 

    // Use this for initialization
    void Start () {

        mappingCollider = GetComponent<SpatialMappingCollider>();
        mappingRenderer = GetComponent<SpatialMappingRenderer>();  

        if ( mappingRenderer == null || mappingCollider == null )
        {
            Debug.Log("Spatial mapping components are misconfigured"); 
            Destroy(this.gameObject); 
        }

        if( autoStart )
        {
            StartScanning(); 
        }
		
	}

    public void StartScanning ()
    { 
        mappingRenderer.enabled = true;
        mappingCollider.enabled = true;
        AllowCollisions = mappingCollider.enableCollisions; 
    }
	
    public void StopScanning ()
    {
        mappingRenderer.enabled = false;
        mappingCollider.enabled = collideWhenNotRendering; 
    }


    public bool AllowCollisions
    {
        get
        {
            return mappingCollider.enableCollisions;  
        }
        set
        {
            mappingCollider.enableCollisions = value; 
        }
     }
	// Update is called once per frame
	void Update () {
		
	}
}
