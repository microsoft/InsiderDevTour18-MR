using System.Collections;
using System.Collections.Generic;
using UnityEngine; 


[RequireComponent(typeof(AudioSource))]
public class SpeechInputFeedback : MonoBehaviour {

    private AudioSource audio;

    public AudioClip positiveFeedbackClip;
    public AudioClip negativeFeedbackClip; 
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>(); 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play ( bool isPositive = true )
    {
        if (audio != null)
        {
            if (isPositive && positiveFeedbackClip != null )                
                audio.PlayOneShot(positiveFeedbackClip, 1f);
            else if  ( negativeFeedbackClip != null )
                audio.PlayOneShot(negativeFeedbackClip, 1f); 
        }
            
    }

    public void Stop ()
    {
        if (audio != null)
            audio.Stop(); 
    }

    public void Pause ()
    {
        if (audio != null )
        {
            audio.Pause(); 
        }
    }


}
