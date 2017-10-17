using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saibablast : MonoBehaviour {

    float speed;
    Vector2 dir;
    bool isReady;

    void Awake()
    {
        speed = 6f;
        isReady = false;
    }

    public void SetDirection(Vector2 direction)
    {
        dir = direction.normalized;
        isReady = true;
    }

    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;

            position += dir * speed * Time.deltaTime;

            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBlast")
        {
            Destroy(gameObject);
        }
    }
}
