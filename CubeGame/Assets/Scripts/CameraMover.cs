using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour
{
    public RectTransform canvasRectTransform;
    public float moveSpeed = 2.0f;  // �������� �����������
    public Vector3 targetPosition;  // �������� �������

    private bool shouldMove = false;

    private void Start()
    {
        StartMoving();
    }
    void Update()
    {
        if (shouldMove)
        {
            // ������� ����������� RectTransform � ������� �������
            canvasRectTransform.anchoredPosition = Vector3.Lerp(canvasRectTransform.anchoredPosition, targetPosition, Time.deltaTime * moveSpeed);

            // ��������� �����������, ���� RectTransform ������ ������� �������
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
