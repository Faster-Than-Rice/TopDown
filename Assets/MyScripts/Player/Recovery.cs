using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recovery : MonoBehaviour
{
    [SerializeField] float refillSpeed;
    [SerializeField] int recoveryValue;
    [SerializeField] Image gaugeImage;
    PlayerDamage damage;
    float recoveryGauge = 100;

    private void Start()
    {
        damage = GetComponent<PlayerDamage>();
    }

    private void FixedUpdate()
    {
        if(recoveryGauge < 100)
        recoveryGauge += refillSpeed;

        gaugeImage.fillAmount = recoveryGauge / 100;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(2) && recoveryGauge >= 25)
        {
            damage.Damage(-recoveryValue);
            recoveryGauge -= 25;
        }
    }
}