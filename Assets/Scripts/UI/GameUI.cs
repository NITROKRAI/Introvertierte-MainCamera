using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    private bool isPaused = false;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused)
            {
                Debug.Log("PauseCanceled");
                Continue();
            }
            else if(!isPaused)
            {
                Debug.Log("PauseActivated");
                Pause();
            }
        }

        OpenDeath();
    }
    
    public void Continue()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OpenDeath()
    {
        if(playerStats.CurrentHealth == 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
