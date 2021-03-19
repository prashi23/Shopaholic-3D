using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausedmenuUI;
    
    // Update is called once per frame
    void Update()
    {
          if (Input.GetKeyDown(KeyCode. Escape))
          {
              if (GameIsPaused)
              {
                  Resume();
              }else
              {
                  Pause();
              }
          } 
    }

    public void Resume ()
    {
        pausedmenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pausedmenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("1 Menu Scene");
    }

    public void Quit ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

