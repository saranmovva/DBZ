using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaibamanControl : MonoBehaviour
{
    public GameObject Explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBlast")
        {
            GameObject explode = (GameObject)Instantiate(Explosion);
            explode.transform.position = transform.position;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Destroy(explode, .8f);
        }
    }
}
