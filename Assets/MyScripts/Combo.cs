using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UniRx;
using UnityEngine.Events;

public class Combo : MonoBehaviour
{
    [SerializeField] float chainTime;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] UnityEvent comboEvent;
    [SerializeField] Image gaugeImage;
    public ReactiveProperty<int> comboCounter
    {
        get;
        private set;
    } = new();
    float comboTimer;
  

    private void Start()
    {
        comboTimer = chainTime;
        comboCounter.Subscribe(value => comboEvent.Invoke());
        comboCounter.Subscribe(value => comboText.text = value.ToString() + "COMBO");
    }

    public void Add()
    {
        comboCounter.Value++;
        comboTimer = chainTime;
    }

    private void FixedUpdate()
    {
        comboTimer -= Time.deltaTime;

        if (comboCounter.Value > 0)
            gaugeImage.fillAmount = comboTimer / chainTime;
        else
            gaugeImage.fillAmount = 1;

        if(comboTimer <= 0)
        {
            comboCounter.Value = 0;
        }
    }
}
