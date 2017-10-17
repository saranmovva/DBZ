using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaibaSpawner : MonoBehaviour {

    public GameObject Saibaman;
    public AudioClip sound;
    public AudioSource audio;

    float spawnRateInSeconds = 8f;

    // Use this for initialization
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        Invoke("SpawnEnemy", spawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject enemy = (GameObject)Instantiate(Saibaman);
        enemy.transform.position = new Vector2(Random.Range(min.x + 10f, max.x - 1f), Random.Range(min.y + 1.2f, max.y - 1.2f));

        SpawnNextEnemy();
    }

    void SpawnNextEnemy()
    {
        float spawnInNSeconds;

        if (spawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, spawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;

        }
        Invoke("SpawnEnemy", spawnInNSeconds);
        PlaySound(sound);
    }

    void IncreaseSpawnRate()
    {
        if (spawnRateInSeconds > 1f)
        {
            spawnRateInSeconds--;
        }
        if (spawnRateInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    private void PlaySound(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}
