using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour {
    private Text text;
    public string variable;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetInt(variable).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
