using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;
using UnityEngine.Audio;
=======
>>>>>>> development
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject optionsMenu;
    public Slider[] volumeSliders;
    public AudioMixer masterMixer;
    // Start is called before the first frame update
    void Start()
=======
    public void BackToMain()
>>>>>>> development
    {
        SceneManager.LoadScene("MainMenu");
    }
<<<<<<< HEAD
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
=======
   
>>>>>>> development
}
