using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlastCollision : MonoBehaviour {

    public GameObject EnemyBlast;
    public AudioClip sound;
    public AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collider collision) {
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
