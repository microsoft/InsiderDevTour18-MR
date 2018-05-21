using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;
//namespace for the TapToPlace script
using HoloToolkit.Unity.SpatialMapping;

public class PlaceHoloLensOnly : MonoBehaviour {

    void Start()
    {
        if (!HolographicSettings.IsDisplayOpaque)
        {
            GetComponent<TapToPlace>().enabled = true;
        }
    }
}
