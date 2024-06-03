using TMPro;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScore;

    private void Start()
    {
        DisplayBestScore();
    }
    private void DisplayBestScore()
    {
        bestScore.text = "BEST\n" + ScoreData.highScore.ToString();
    }
}
