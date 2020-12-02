using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;
    private int highScore;
    public UpdateScore updateScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }


    public void IncrementScore(int score)
    {
        this.score += score;

        if(this.score > highScore)
        {
            highScore = this.score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        
        updateScore?.Invoke(this.score);
    }

    public delegate void UpdateScore(int score);
}
