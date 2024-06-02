using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject doubleObstacle;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float speedMultiplier;

    public float _currentSpeed => this.currentSpeed;

    public float _speedMultiplier => this.speedMultiplier;

    public Canvas _canvas => this.canvas;

    private void Awake()
    {
        currentSpeed = minSpeed;
    }

    private void Start()
    {
        InvokeRepeating("GenerateObstacles", 0f, 0.8f);
    }

    private void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedMultiplier * Time.deltaTime;
        }
    }

    public void GenerateObstacles()
    {
        GameObject obst;

        if (ScoreData.instance._score >= 5)
        {
            obst = Instantiate(doubleObstacle);
        }
        else
        {
            obst = Instantiate(obstacle);
        }

        obst.transform.SetParent(canvas.transform, false);
        SetRectTransformPosition(obst, spawnPosition);
        AssignObstacleGenerator(obst);
        Destroy(obst, 5);
    }

    public void SetRectTransformPosition(GameObject obj, Vector2 position)
    {
        RectTransform rectTransform = obj.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = position;
        }
        else
        {
            obj.transform.position = new Vector3(position.x, position.y, obj.transform.position.z);
        }
    }

    public void AssignObstacleGenerator(GameObject obj)
    {
        ObstacleManager obstacleManager = obj.GetComponent<ObstacleManager>();
        if (obstacleManager != null)
        {
            obstacleManager.obstacleGenerator = this;
        }
    }
}
