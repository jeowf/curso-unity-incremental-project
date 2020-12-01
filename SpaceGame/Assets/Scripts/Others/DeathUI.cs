using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    public GameObject deathMenu;
    public string scene;

    public void DeathMenuOpen()
    {
        Time.timeScale = 0f;
        deathMenu.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene);
        deathMenu.SetActive(false);
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        deathMenu.SetActive(false);
    }
}
