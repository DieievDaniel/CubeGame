using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        DisplayScore();
    }

    public void DisplayScore()
    {
        scoreText.text = ScoreData.instance._score.ToString();
    }
}
