using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingCursor : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
