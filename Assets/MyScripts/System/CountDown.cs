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
    [SerializeField] GameObject clearEffect;
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
            clearEvent.Invoke();
            clearEffect.SetActive(true);
            GetComponent<PlayerDamage>().enabled = false;
            GetComponent<AudioMute>().Mute(true);
            GetComponent<Score>().enabled = false;
            GameObject.Find("HUD").SetActive(false);
            this.enabled = false;
        }
    }
}
