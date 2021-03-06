﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    public GameObject EnemyBlast;
    public AudioClip sound;
    public AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = gameObject.GetComponent<AudioSource>();
        InvokeRepeating("Fire", .5f, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Fire()
    {
        GameObject player = GameObject.Find("GokuFly");

        if(player != null)
        {
            GameObject shoot = (GameObject)Instantiate(EnemyBlast);

            shoot.transform.position = transform.position;

            Vector2 direction = player.transform.position - shoot.transform.position;

            shoot.GetComponent<EnemyKi>().SetDirection(direction);
            AudioSource audio = GetComponent<AudioSource>();
            PlaySound(sound);
        }
    }

    private void PlaySound(AudioClip clip)
    {
        audio.clip = clip;
        audio.PlayOneShot(clip);
    }
}
