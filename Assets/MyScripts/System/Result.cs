using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using unityroom.Api;

public class Result : MonoBehaviour
{
    [System.NonSerialized] public static int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI rankText;

    private void Start()
    {
        UnityroomApiClient.Instance.SendScore(1, score, ScoreboardWriteMode.HighScoreDesc);
        scoreText.text = score.ToString();

        if(score <= 0)
        {
            rankText.text = "Beginner";
        }
        else if(score <= 50000)
        {
            rankText.text = "Intermediate";
        }
        else if(score <= 100000)
        {
            rankText.text = "Advanced";
        }
        else if(score <= 200000)
        {
            rankText.text = "Expert";
        }
        else if(score <= 300000)
        {
            rankText.text = "Ace";
        }
        else if(score <= 400000)
        {
            rankText.text = "Legend";
        }
        else
        {
            rankText.text = "The One-Man Army";
        }
    }
}
