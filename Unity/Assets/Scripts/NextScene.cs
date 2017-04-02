using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScene : MonoBehaviour {

    public string nextScene;
    public float delay;

    private float deltatime;
	
	
    void Start()
    {
        deltatime = 0f;
    }
	void Update () {
        deltatime += Time.deltaTime;

        if (Input.GetButtonDown("Ability1") && deltatime >= delay)
        {
            Application.LoadLevel(nextScene);
        }
	}
}
