﻿using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class GameSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    public Toggle fullScreenToggle;
    // Start is called before the first frame update
    void Start()
    {
        fullScreenToggle.isOn = PlayerPrefs.GetInt("isFullscreen", 1) == 1;

        if (fullScreenToggle.isOn)
        {
            SetFullScreenMode();
        }
        else
        {
            SetWindowedMode();
        }
        fullScreenToggle.isOn = Screen.fullScreenMode == FullScreenMode.FullScreenWindow;

        InitVolume();
    }
    public void SetMusicVolume(float value)
    {
        float dB = (value > 0) ? Mathf.Log10(value) * 20 : -80f;
        audioMixer.SetFloat("MusicVolume", dB);

        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void SetSFXVolume(float value)
    {
        float dB = (value > 0) ? Mathf.Log10(value) * 20 : -80f;
        audioMixer.SetFloat("SFXVolume", dB);

        PlayerPrefs.SetFloat("SFXVolume", value);

    }
    
    public void LoadSFXVolume()
    {
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
    public void LoadMusicVolume()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }
    public void OnFullScreenToggleChanged(bool isFullscreen)
    {
        if (isFullscreen)
        {
            SetFullScreenMode();
        }
        else
        {
            SetWindowedMode();
        }
        PlayerPrefs.SetInt("isFullscreen", isFullscreen ? 1 : 0);
    }
    void SetFullScreenMode()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
    }
    void SetWindowedMode()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.SetResolution(1920 * 2 / 3, 1080 * 2 / 3, false);
    }
    void InitVolume()
    {
        // Đọc giá trị từ PlayerPrefs, mặc định là 0 nếu chưa lưu
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);

        // Đặt giá trị cho Slider
        sfxVolumeSlider.value = savedSFXVolume;
        musicVolumeSlider.value = savedMusicVolume;

        // Đặt giá trị cho Audio Mixer
        float SFXdB = (savedSFXVolume > 0) ? Mathf.Log10(savedSFXVolume) * 20 : -80f;
        float MusicdB = (savedSFXVolume > 0) ? Mathf.Log10(savedMusicVolume) * 20 : -80f;
        audioMixer.SetFloat("SFXVolume", SFXdB);
        audioMixer.SetFloat("MusicVolume", MusicdB);
    }
}
