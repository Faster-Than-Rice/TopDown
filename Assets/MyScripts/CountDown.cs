using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] float limitTime;
    [SerializeField] TextMeshProUGUI counterText;
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
    }
}
