using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaEvent : MonoBehaviour
{
    [SerializeField] string targetTag = "Player";
    [SerializeField] UnityEvent areaEvent;
    bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && !isActive)
        {
            isActive = true;
            areaEvent.Invoke();
            Destroy(this);
        }
    }
}
