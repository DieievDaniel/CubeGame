using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour
{
    public RectTransform canvasRectTransform;
    public float moveSpeed = 2.0f;  // Скорость перемещения
    public Vector3 targetPosition;  // Конечная позиция

    private bool shouldMove = false;

    private void Start()
    {
        StartMoving();
    }
    void Update()
    {
        if (shouldMove)
        {
            // Плавное перемещение RectTransform к целевой позиции
            canvasRectTransform.anchoredPosition = Vector3.Lerp(canvasRectTransform.anchoredPosition, targetPosition, Time.deltaTime * moveSpeed);

            // Остановка перемещения, если RectTransform достиг целевой позиции
            if (Vector3.Distance(canvasRectTransform.anchoredPosition, targetPosition) < 0.01f)
            {
                shouldMove = false;
            }
        }
    }

    public void StartMoving()
    {
        shouldMove = true;
    }
}
