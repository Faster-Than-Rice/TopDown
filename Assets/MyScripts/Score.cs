using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] UnityEvent scoreEvent;
    [SerializeField] OperateDialogue dialogue;
    public int scoreCounter
    {
        get;
        private set;
    }
    Combo combo;

    private void Start()
    {
        combo = GetComponent<Combo>();
        GameObject.FindGameObjectWithTag("Operator").GetComponent<Operator>().SetDialogues(dialogue);
    }

    public void AddScore(int value)
    {
        scoreCounter += Mathf.CeilToInt(value * (1 + combo.comboCounter.Value / 10));
        scoreEvent.Invoke();
        scoreText.text = "SCORE:" + scoreCounter.ToString();
    }
}
