using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Storm : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    [SerializeField] ParticleSystem particle;
    ParticleSystem.MainModule main;

    private void Start()
    {
        main = particle.main;
    }

    public void Change()
    {
        if (!toggle.isOn)
        {
            main.simulationSpeed = 1;
        }
        else
        {
            main.simulationSpeed = 10;
        }
    }
}
