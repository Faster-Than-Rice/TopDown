using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;

public class CountDown : MonoBehaviour
{
    [SerializeField] float limitTime;
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] GameObject fade;
    [SerializeField] UnityEvent clearEvent;

    public float counter
    {
        get;
        private set;
    }

    private void Start()
    {
        counter = limitTime;
    }

    private void Update()
    {
        counter -= Time.deltaTime;
        counter = Mathf.Clamp(counter, 0, counter);
        counterText.text = TimeSpan.FromSeconds(counter).ToString(@"mm\:ss\:ff");

        if(counter <= 0)
        {
            Result.score = GetComponent<Score>().scoreCounter;
            Invoke(new Action(() => fade.GetComponent<DOTweenAnimation>().DOPlayBackwards()).Method.Name, 2);
            clearEvent.Invoke();
        }
    }
}
