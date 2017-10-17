using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public GameObject KiBlast;
    public GameObject KiBlastPosition;
    public AudioClip sound;
    public AudioSource audio;
    public float speed;

	// Use this for initialization
	void Start () {
        audio = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            GameObject kiblast = (GameObject)Instantiate(KiBlast);
            kiblast.transform.position = KiBlastPosition.transform.position;
            PlaySound(sound);

        }

        float y = Input.GetAxisRaw("Vertical");
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
        ScoreTracker.Score++;
	}

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 12f;
        min.x = min.x + 1f;

        max.y = max.y - 1.2f;
        min.y = min.y + 1.2f;


        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBlast")
        {
            Destroy(gameObject);
            SceneManager.UnloadSceneAsync("GameEngine");
            SceneManager.LoadScene("Score");
        }
    }

    private void PlaySound(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}
