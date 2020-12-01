using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayNaveButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void PlayPlataformaButton()
    {
        SceneManager.LoadScene("Plataform2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
