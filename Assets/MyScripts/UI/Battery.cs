using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battery : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        slider.value = SystemInfo.batteryLevel;
        text.text = (SystemInfo.batteryLevel * 100).ToString("f00") + "%";
    }
}
