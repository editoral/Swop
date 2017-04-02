using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0F;
    public LayerMask obstacleLayer;
    public LayerMask playerLayer;
    public GameObject player;
    public float attackRange;
    public int health;
    public string type;
    public int attackInterval;
    public GameObject attackCollider;

    private float timeStamp;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        attack(direction);
        move(direction);
    }

    private void attack(Vector2 direction)
    {
        if (timeStamp <= Time.time)
        {
            Sound sound = GetComponent<Sound>();
            sound.PlayAttack();
            timeStamp = Time.time + attackInterval;
            Collider2D coll = attackCollider.GetComponent<Collider2D>();
            coll.enabled = true;
        }
    }

    private void move(Vector2 direction)
    {
        Rigidbody2D rg = GetComponent<Rigidbody2D>();
        rg.MovePosition(rg.position + direction * Time.fixedDeltaTime);
    }

    public void takeDamage(int dmg)
    {
        health -= dmg;
        Sound sound = GetComponent<Sound>();
        if (health < 0)
        {
            sound.PlayDeath();
            Destroy(gameObject, sound.deathSound.length);
        } else
        {
            sound.PlayHit();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            if (this.type.Equals("Knirps"))
            {
                Bullet bullet = other.GetComponent<Bullet>();
                takeDamage(bullet.damage);
            }
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Beever_feever"))
        {
            if (this.type.Equals("Mops"))
            {
                other.enabled = false;
                takeDamage(5);
            }
        }
    }

}
