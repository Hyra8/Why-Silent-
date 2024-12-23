using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    public bool loop;

    public AudioMixerGroup audioMixerGroup;
    [HideInInspector]
    public AudioSource audioSource;
}
