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
