using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public float health = 100f;
    public float maxSize;
    public float maxPos;
    public float minPos;
    public float offset;

    

    public GameObject foreground;


	void Start () {
	}

	void Update () {
        AdjustHealth();
	}

    void AdjustHealth()
    {
        float scale = maxSize / 100 * health;
        foreground.transform.localScale = new Vector3(foreground.transform.localScale.x, scale, foreground.transform.localScale.z);
        float pos = minPos + (maxPos - minPos) / 100f * health;
        foreground.transform.position = new Vector3(foreground.transform.position.x, pos + offset, foreground.transform.position.z);
    }
}
