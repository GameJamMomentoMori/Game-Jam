using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public Object menu;

    // Update is called once per frame
    void Update()
    {
        // Pauses the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(GamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        CursorLock.cursorLocked = true;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        CursorLock.cursorLocked = false;
        GamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
