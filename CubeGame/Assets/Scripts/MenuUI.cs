using TMPro;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestScore;
    #region MONO
    private void Start()
    {
        DisplayBestScore();
    }
    #endregion
    private void DisplayBestScore()
    {
        bestScore.text = "BEST\n" + ScoreData.highScore.ToString();
    }
}
