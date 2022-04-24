using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip clip;

    public string name;

    [Range(0f, 1f)]
    public float volume;
     
    [Range(.1f, 3f)]
    public float pitch;

    [Range(0, 256)]
    public int priority;

    [Range(0f, 1.0f)]
    public float spatialBlend;

    public AudioRolloffMode rolloffMode;

    public int minDistance;

    public int maxDistance;

    [HideInInspector]
    public AudioSource source;
}
