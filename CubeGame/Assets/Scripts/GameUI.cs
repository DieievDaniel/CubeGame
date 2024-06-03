using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI fpsText;

    public TextMeshProUGUI _fpsText => this.fpsText;
    #region MONO
    private void Start()
    {
        DisplayScore();
        
    }
    private void Update()
    {
        DisplayFPS();
    }
    #endregion

    public void DisplayScore()
    {
        scoreText.text = ScoreData.instance._score.ToString();
    }

    private void DisplayFPS()
    {
        ScoreData.instance._fps = (int)(1 / Time.deltaTime);
        fpsText.text = "FPS: " + ScoreData.instance._fps.ToString();
    }

}
