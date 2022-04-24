using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundInterval : MonoBehaviour
{
    public float soundCooldown = 0.9f;
    public AudioSource sound;

    private float nextSound = 0;

    void Update()
    {
        if(Time.time > nextSound)
        {
            sound.Play();
            nextSound = Time.time + soundCooldown;
        }
    }
}
