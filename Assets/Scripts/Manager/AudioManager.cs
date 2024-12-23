using System;
using UnityEngine;

/// <summary>
/// Lớp quản lý âm thanh
/// </summary>
/// <author> Nguyễn Việt Hoàn </author>
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

    /// <summary>
    /// Hàm chạy nhạc theo tên sound
    /// </summary>
    /// <param name="soundName">Tên sound</param>
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

    /// <summary>
    /// Hàm tắt nhạc theo tên sound
    /// </summary>
    /// <param name="soundName">Tên sound</param>
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

    /// <summary>
    /// Hàm chạy soundEffect theo tên sound
    /// </summary>
    /// <param name="soundName"></param>
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

    /// <summary>
    /// Hàm tắt soundEffect theo tên sound
    /// </summary>
    /// <param name="soundName">tên Sound</param>
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
