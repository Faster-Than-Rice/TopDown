using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    [System.NonSerialized] public static int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI rankText;

    private void Start()
    {
        scoreText.text = score.ToString();

        if(score <= 5000)
        {
            rankText.text = "Beginner";
        }
        else if(score <= 10000)
        {
            rankText.text = "Ordinaly";
        }
        else if(score <= 20000)
        {
            rankText.text = "Expert";
        }
        else if(score <= 40000)
        {
            rankText.text = "Ace";
        }
        else if(score <= 50000)
        {
            rankText.text = "Legend";
        }
        else
        {
            rankText.text = "";
        }
    }
}
