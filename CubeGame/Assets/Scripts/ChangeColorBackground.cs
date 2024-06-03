using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColorChanger : MonoBehaviour
{
    [SerializeField] private Image targetImage;
    private int previousScore = 0;


    void Update()
    {
        if (ScoreData.instance._score != previousScore)
        {
            if (ScoreData.instance._score % 2 == 0 && ScoreData.instance._score > previousScore)
            {
                ChangeToRandomColor();
            }

            previousScore = ScoreData.instance._score;
        }
    }

    public void ChangeToRandomColor()
    {
        if (targetImage != null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            targetImage.color = randomColor;
        }
    }
}
