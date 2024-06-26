using UnityEngine.SceneManagement;
using UnityEngine;


public class CubeCollision : MonoBehaviour
{
    [SerializeField] private GameUI gameUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            ScoreData.instance._score += 1;
            AudioManager.instance.PlayCoinPickupSound();
            gameUI.DisplayScore();
            Destroy(collision.gameObject);

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
