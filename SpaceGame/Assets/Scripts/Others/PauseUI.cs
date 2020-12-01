using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject playerUi;
    public GameObject pauseUi;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        playerUi.SetActive(false);
        pauseUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        playerUi.SetActive(true);
        pauseUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
