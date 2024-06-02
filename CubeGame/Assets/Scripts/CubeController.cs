using System.Collections;
using UnityEngine;

public class CubeGravityController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private RectTransform floor;
    [SerializeField] private float gravityScale;
    [SerializeField] private float transitionSpeed;

    private bool moveToLeft = true;
    private bool isFalling = false; 

    #region MONO
    void Start()
    {
        rb.gravityScale = 0;
    }

    void Update()
    {
        if (transform.position.y <= floor.position.y)
        {
            ChangeGravity(-gravityScale);
        }
    }
    #endregion

    public void StartFalling()
    {
        if (!isFalling)
        {
            isFalling = true; 
            StartCoroutine(ChangeGravitySmoothly(gravityScale));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            StartCoroutine(ChangeGravitySmoothly(-gravityScale));
        }
        else if (collision.gameObject.CompareTag("Ceiling"))
        {
            StartCoroutine(ChangeGravitySmoothly(0));
            StartCoroutine(MoveToPoint());
        }
    }

    private void ChangeGravity(float newGravityScale)
    {
        rb.gravityScale = newGravityScale;
    }

    private IEnumerator ChangeGravitySmoothly(float targetGravityScale)
    {
        float transitionGravitySpeed = 20;
        float startGravityScale = rb.gravityScale;
        float elapsedTime = 0f;
        float duration = 1f / transitionGravitySpeed;

        while (elapsedTime < duration)
        {
            rb.gravityScale = Mathf.SmoothStep(startGravityScale, targetGravityScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rb.gravityScale = targetGravityScale;
    }

    private IEnumerator MoveToPoint()
    {
        float moveDistance = moveToLeft ? -1.5f : 1.5f;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(startPosition.x + moveDistance, startPosition.y, startPosition.z);

        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime);
            elapsedTime += Time.deltaTime * transitionSpeed;
            yield return null;
        }

        transform.position = endPosition;

        moveToLeft = !moveToLeft;

        rb.gravityScale = 0;
        isFalling = false; 

        Debug.Log($"Moved to point: {(moveToLeft ? "Right" : "Left")}");
    }
}
