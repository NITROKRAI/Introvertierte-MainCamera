using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{

    public GameObject optionsMenu;
    public Slider[] volumeSliders;
    public AudioMixer masterMixer;
    // Start is called before the first frame update
    void Start()
    {
        volumeSliders[0].value = PlayerPrefs.GetFloat("MasterVol"); 
        volumeSliders[1].value = PlayerPrefs.GetFloat("MusicVol"); 
        volumeSliders[2].value = PlayerPrefs.GetFloat("SFXVol");
    }

    public void BackToMain()

    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SetMasterVolume(float sliderValue)
    {
        masterMixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVol", sliderValue);
    }
    public void SetMusicVolume(float sliderValue)
    {
        masterMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVol", sliderValue);
    }
    public void SetSFXVolume(float sliderValue)
    {
        masterMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVol", sliderValue);
    }

    public void FullscreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}

