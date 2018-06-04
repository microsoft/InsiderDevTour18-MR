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
