using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public AudioClip sound;
    public AudioSource audio;

    public void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        PlaySound(sound);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void PlaySound(AudioClip clip)
    {
        audio.clip = clip;
        audio.Play();
    }
}
