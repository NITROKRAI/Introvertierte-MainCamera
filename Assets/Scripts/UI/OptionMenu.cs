using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public Slider[] VolumeSliders;
    public AudioMixer MasterMixer;

    // Start is called before the first frame update
    void Start()
    {
        VolumeSliders[0].value = PlayerPrefs.GetFloat("MasterVol"); 
        VolumeSliders[1].value = PlayerPrefs.GetFloat("MusicVol"); 
        VolumeSliders[2].value = PlayerPrefs.GetFloat("SFXVol");
    }

    public void BackToMain()

    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetMasterVolume(float sliderValue)
    {
        MasterMixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVol", sliderValue);
    }

    public void SetMusicVolume(float sliderValue)
    {
        MasterMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        MasterMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVol", sliderValue);
    }

    public void FullscreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}

