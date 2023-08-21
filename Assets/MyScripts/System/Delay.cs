using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Delay : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] UnityEvent delayEvent;

    private void Start()
    {
        StartCoroutine(nameof(Execution));
    }

    IEnumerator Execution()
    {
        yield return new WaitForSeconds(delay);
        delayEvent.Invoke();
    }
}
