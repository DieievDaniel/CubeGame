using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleGenerator obstacleGenerator;

    private void Update()
    {
        transform.Translate(Vector2.left * obstacleGenerator._currentSpeed * Time.deltaTime);
    }

}
