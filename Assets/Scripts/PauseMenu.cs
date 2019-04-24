using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    private bool optionsMenu = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused && optionsMenu == false)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Options()
    {
        optionsMenu = true;
    }
    public void CloseOptions()
    {
        optionsMenu = false;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Title Screen");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
