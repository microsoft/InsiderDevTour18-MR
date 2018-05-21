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
