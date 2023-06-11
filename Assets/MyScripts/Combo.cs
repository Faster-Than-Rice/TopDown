using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combo : MonoBehaviour
{
    [SerializeField] float chainTime;
    [SerializeField] TextMeshProUGUI comboText;
    int comboCounter;
    float comboTimer;

    private void Start()
    {
        comboTimer = chainTime;
    }

    public void Add()
    {
        comboCounter++;
        comboTimer = chainTime;
    }

    private void FixedUpdate()
    {
        comboTimer -= Time.deltaTime;

        if(comboTimer <= 0)
        {
            comboCounter = 0;
        }

        comboText.text = comboCounter.ToString() + "Combo";
    }
}
