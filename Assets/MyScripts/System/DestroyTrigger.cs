using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyTrigger : MonoBehaviour
{
    [SerializeField] AreaSensor sensor;
    [SerializeField] List<GameObject> objects;
    [SerializeField] UnityEvent destroyEvent;
    [SerializeField] UnityEvent destroySensingEvent;
    bool isDestory = false;

    private void FixedUpdate()
    {
        for (int counter = 0; counter <= objects.Count - 1; counter++)
        {
            if (objects[counter] == null)
            {
                objects.RemoveAt(counter);

                if (objects.Count == 0 && !isDestory)
                {
                    isDestory = true;
                    if(sensor && sensor.GetValue())
                    {
                        destroySensingEvent.Invoke();
                    }
                    else
                    {
                        destroyEvent.Invoke();
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
