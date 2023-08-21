using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    Toggle toggle;
    [SerializeField] GameObject tab;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    private void Update()
    {
        tab.SetActive(toggle.isOn);
    }
}
