using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public static ScoreData instance;

    private int fps;
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
    public int _fps
    {
        get => this.fps;
        set
        {
            this.fps = value;
            
        }
    }

    #region MONO
    private void Awake()
    {
        instance = this;
        LoadHighScore();
    }
    #endregion
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
