using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaibablastCollision : MonoBehaviour {

    public GameObject EnemyBlast;
    public AudioClip sound;
    public AudioSource audio;


    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collider collision)
    {
        if (collision.gameObject.tag == "EnemyBlast" || collision.gameObject.tag == "SaibaBlast")
        {
            Physics.IgnoreCollision(EnemyBlast.GetComponent<Collider>(), collision);
        }

    }

    private void PlaySound(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}
