using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Clock : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        DateTime date = DateTime.Now;
        text.text = date.Hour.ToString("00") + ":" + date.Minute.ToString("00");
    }
}
