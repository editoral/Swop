using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {
    public AudioClip deathSound;
    public AudioClip spawnSound;
    public AudioClip attackSound;
    public AudioClip hitSound;

    private AudioSource audioplayer;

    void Start()
    {
        audioplayer = gameObject.GetComponent<AudioSource>();
    }

    public void PlayAttack()
    {
        audioplayer.Stop();
        audioplayer.clip = attackSound;
        audioplayer.Play();
    }
    public void PlaySpawn()
    {
        audioplayer.Stop();
        audioplayer.clip = spawnSound;
        audioplayer.Play();
    }

    public void PlayDeath()
    {
        audioplayer.Stop();
        audioplayer.clip = deathSound;
        audioplayer.Play();
    }
    public void PlayHit()
    {
        audioplayer.Stop();
        audioplayer.clip = hitSound;
        audioplayer.Play();
    }
}
