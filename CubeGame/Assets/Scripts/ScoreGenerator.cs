using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGenerator : MonoBehaviour
{
    [SerializeField] private GameObject scoreObject;
    [SerializeField] private Vector2 spawnPosition;

    [SerializeField] private ObstacleGenerator obstacleGenerator;

    private void Start()
    {
        InvokeRepeating("GenerateScore", 0f, 2.4f);
    }

    private void GenerateScore()
    {
        GameObject score = Instantiate(scoreObject);
        score.transform.SetParent(obstacleGenerator._canvas.transform, false);
        obstacleGenerator.SetRectTransformPosition(score, spawnPosition);
        obstacleGenerator.AssignObstacleGenerator(score);
        Destroy(score, 5);
    }
}
