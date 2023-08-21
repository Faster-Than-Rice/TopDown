using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyTrigger : MonoBehaviour
{
    [SerializeField] List<GameObject> objects;
    [SerializeField] UnityEvent destroyEvent;

    private void FixedUpdate()
    {
        for (int counter = 0; counter <= objects.Count - 1; counter++)
        {
            if (objects[counter] == null)
            {
                objects.RemoveAt(counter);

                if (objects.Count == 0)
                {
                    destroyEvent.Invoke();
                    Destroy(gameObject);
                }
            }
        }
    }
}
