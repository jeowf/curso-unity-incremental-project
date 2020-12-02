using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    public UpdateScore updateScore;


    public void IncrementScore(int score)
    {
        this.score += score;
        updateScore?.Invoke(this.score);
    }

    public delegate void UpdateScore(int score);
}
