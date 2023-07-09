using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour, IDamage
{
    int damage;

    public void Damage(int damageValue)
    {
        damage += damageValue;
        Debug.Log(damage);
    }
}