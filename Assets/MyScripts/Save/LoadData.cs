using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(SaveManager.Load());
    }
}
