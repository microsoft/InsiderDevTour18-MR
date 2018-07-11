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

public class HololensManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (!UnityEngine.XR.WSA.HolographicSettings.IsDisplayOpaque)
        {
            /// DEMO HACK...  
            // for occluded part of the demo, we scaled the cursor to be quite large so it was very visible in demo. 
            // With this, we scale it a little so it is not so overwhelming in Hololens. We should have demoer do this on stage instead of adding this, but that takes extra time.
            // Since this a very explicit hack in the demo, i do check for exactly same cursor type.. 
            var cursor = GameObject.FindObjectOfType<HoloToolkit.Unity.InputModule.ObjectCursor>();
            if (cursor != null)
            {
                var cursorOn = cursor.gameObject.transform.Find("CursorOnHolograms");
                if (cursorOn != null)
                {
                    if (cursorOn.transform.localScale.x > 3)
                    {
                        Vector3 half = cursorOn.transform.localScale / 2; 
                        cursorOn.transform.localScale = half ;
                    }
                }
            }
        } 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
