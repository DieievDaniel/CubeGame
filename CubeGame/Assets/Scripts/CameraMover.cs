using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRectTransform;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 targetPosition;  

    private bool shouldMove = false;

    #region MONO
    private void Start()
    {
        StartMoving();
    }
    void Update()
    {
        if (shouldMove)
        {
            canvasRectTransform.anchoredPosition = Vector3.Lerp(canvasRectTransform.anchoredPosition, targetPosition, Time.deltaTime * moveSpeed);
           
            if (Vector3.Distance(canvasRectTransform.anchoredPosition, targetPosition) < 0.01f)
            {
                shouldMove = false;
            }
        }
    }
    #endregion
    public void StartMoving()
    {
        shouldMove = true;
    }
}
