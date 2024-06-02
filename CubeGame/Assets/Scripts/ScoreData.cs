using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    public static ScoreData instance;

    private int score;
    private int highScore;

    public int _score
    {
        get => this.score;
        set => this.score = value;
    }

    public int _highScore
    {
        get => this.highScore;
        set => this.highScore = value;
    }

    private void Awake()
    {
        instance = this;
    }
}
