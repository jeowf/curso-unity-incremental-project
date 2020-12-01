using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUINave : MonoBehaviour
{
    public static bool GameIsPaused = false;
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
        pauseUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
