using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Enemy") && collision.gameObject.name.Contains("Bullet"))
        {

        }
    }
}
