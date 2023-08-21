using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    [SerializeField] Vector3 torque;

    private void FixedUpdate()
    {
        transform.Rotate(torque);
    }
}
