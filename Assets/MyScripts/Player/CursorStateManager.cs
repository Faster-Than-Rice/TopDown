using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorStateManager : MonoBehaviour
{
    [SerializeField] CursorLockMode lockMode;
    [SerializeField] bool isHide;

    private void FixedUpdate()
    {
        Cursor.lockState = lockMode;
        Cursor.visible = isHide;
    }
}
