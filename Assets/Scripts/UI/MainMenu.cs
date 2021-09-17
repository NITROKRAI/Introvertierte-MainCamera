using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level-Tutorial");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("OptionMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
