using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StageSelectButton : MonoBehaviour
{
    [SerializeField] Button start;
    [SerializeField] UnityEvent clickEvent;

    public void SetEvent()
    {
        start.onClick.AddListener(() => clickEvent.Invoke());
    }
}
