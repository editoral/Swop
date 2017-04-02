using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {
    public int score;
    private int highScore;
    private float deltatimeTime;
    private float step = 0.1f;

	void Start () {
        highScore = PlayerPrefs.GetInt("HighScore");
        score = 0;
        deltatimeTime = 0f;
	}
	
	void Update () {
        deltatimeTime += Time.deltaTime;
        if( deltatimeTime >= step)
        {
            score++;
            deltatimeTime -= step;
        }
	}

    void OnDisable ()
    {
        PlayerPrefs.SetInt("LastScore", score);
        if (highScore <= score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
