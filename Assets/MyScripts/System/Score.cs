using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] UnityEvent scoreEvent;
    [SerializeField] int missionNumber;
    public int scoreCounter
    {
        get;
        private set;
    }
    Combo combo;

    private void Start()
    {
        combo = GetComponent<Combo>();
    }

    public void AddScore(int value)
    {
        if(enabled)
        scoreCounter += Mathf.CeilToInt(value * (1 + combo.comboCounter.Value / 10));
        scoreEvent.Invoke();
        scoreText.text = "SCORE:" + scoreCounter.ToString();
    }

    public void SaveScore()
    {
        if(scoreCounter > SaveManager.save.highScores[missionNumber])
        SaveManager.save.highScores[missionNumber] = scoreCounter;
    }
}
