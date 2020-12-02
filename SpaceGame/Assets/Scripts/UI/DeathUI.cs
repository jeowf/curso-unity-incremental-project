using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    public GameObject deathMenu;
    public Text scoreText;
    public string scene;

    public void DeathMenuOpen()
    {
        Time.timeScale = 0f;
        deathMenu.SetActive(true);
        scoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
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
        SceneManager.LoadScene("Menu");
        deathMenu.SetActive(false);
    }
}