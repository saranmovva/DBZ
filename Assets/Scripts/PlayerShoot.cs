using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    float speed;
	// Use this for initialization
	void Start () {
        speed = 15f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;

        position = new Vector2(position.x + speed * Time.deltaTime, position.y);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.x > max.x)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBlast")
        {
            Destroy(gameObject);
        }
    }
}
