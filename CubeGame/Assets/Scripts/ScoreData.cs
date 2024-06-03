using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public static ScoreData instance;

    private int score;
    public static int highScore;

    public int _score
    {
        get => this.score;
        set
        {
            this.score = value;
            CheckHighScore();
        }
    }

    private void Awake()
    {
        instance = this;
        LoadHighScore();
    }

    private void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}
