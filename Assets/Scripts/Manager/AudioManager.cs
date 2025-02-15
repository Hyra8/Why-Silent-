using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] soundEffects;
    public Sound[] musics;
    [Range(0f, 1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float soundEffectVolume = 1f;
    void Awake()
    {
        if (instance == null)
            instance = this;
        //else
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //DontDestroyOnLoad(gameObject);

        foreach (Sound s in musics)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume * musicVolume;
            s.audioSource.loop = s.loop;
            s.audioSource.outputAudioMixerGroup = s.audioMixerGroup;
        }
        foreach (Sound s in soundEffects)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume = s.volume * soundEffectVolume;
            s.audioSource.loop = s.loop;
            s.audioSource.outputAudioMixerGroup = s.audioMixerGroup;
        }
    }
    private void Start()
    {

    }

    public void PlayMusic(string soundName)
    {
        Sound s = Array.Find(musics, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
            return;
        }
        Debug.Log(s.name);
        s.audioSource.Play();
    }

    public void StopMusic(string soundName)
    {
        Sound s = Array.Find(musics, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
            return;
        }
        s.audioSource.Stop();
    }

    public void PlaySoundEffect(string soundName)
    {
        Sound s = Array.Find(soundEffects, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
            return;
        }
        Debug.Log(s.name);
        s.audioSource.Play();
    }

    public void StopSoundEffect(string soundName)
    {
        Sound s = Array.Find(soundEffects, sound => sound.name == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + soundName + " not found");
            return;
        }
        s.audioSource.Stop();
    }
}
