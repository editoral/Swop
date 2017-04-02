using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 10.0f;
    public int damage;
    public LayerMask obstacleLayer;

    public Vector2 _movement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (_movement.magnitude > 0)
        {
            Vector2 translation = _movement * Time.fixedDeltaTime * speed;
            transform.Translate(translation.x, translation.y, 0);
        }

	}

    public void setMovement(Vector2 movement)
    {
        _movement = movement;
    }
}
