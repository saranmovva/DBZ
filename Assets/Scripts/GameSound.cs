using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour {
    public AudioClip sound;
    public AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = gameObject.GetComponent<AudioSource>();
        PlaySound(sound);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void PlaySound(AudioClip clip)
    {
        audio.clip = clip;
        audio.PlayOneShot(clip);
    }
}
