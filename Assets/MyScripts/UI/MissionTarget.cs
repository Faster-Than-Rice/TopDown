using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionTarget : MonoBehaviour
{
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void SetText(string value)
    {
        text.text = value;
    }
}
