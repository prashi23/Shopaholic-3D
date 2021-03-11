using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Resume ()
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
}
