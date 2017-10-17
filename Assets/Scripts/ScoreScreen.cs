using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScreen : MonoBehaviour {

    Text score;

    private void Start()
    {
        score = GameObject.Find("ScoreText").GetComponent<Text>();
        score.text += ScoreTracker.Score;
    }

    void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("MainMenu");
            ScoreTracker.Score = 0;
        }
    }
}
