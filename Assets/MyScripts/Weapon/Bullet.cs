using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] int damage;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    //ñΩíÜèàóù
    private void OnCollisionEnter(Collision collision)
    {
        IDamage target = collision.gameObject.GetComponent<IDamage>();
        GetComponent<Collider>().enabled = false;
        if (target != null)
        {
            target.Damage(damage);
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
