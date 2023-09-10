using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaSensor : MonoBehaviour
{
    [SerializeField] string targetTag = "Player";
    bool isTrigger = false;

    public bool GetValue()
    {
        return isTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(targetTag))
        isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag(targetTag))
        isTrigger = false;
    }
}
