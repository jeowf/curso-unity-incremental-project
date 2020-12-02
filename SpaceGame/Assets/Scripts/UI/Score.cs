using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    //public PlayerShip playerShip;
    // Start is called before the first frame update

    private ScoreManager scoreManager;
    void OnEnable()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        scoreManager.updateScore += UpdateScore;
    }

    void OnDisablee()
    {
        scoreManager.updateScore -= UpdateScore;
    }


    void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
