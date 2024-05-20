using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject PauseMenuUI;
    public GameObject DeathMenuUI;
    public bool dead;
    public LevelManager LM;

    void Start()
    {
        dead = false;
        DeathMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !dead)
        {
            if(gamePaused)
            {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        LM.LoadNextLevel();
    }

    public void DeathScreen()
    {
        dead = true;
        DeathMenuUI.SetActive(true);
    }
}
