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

    //��������
    private void OnCollisionEnter(Collision collision)
    {
        EnemyStatus target = collision.gameObject.GetComponent<EnemyStatus>();
        GetComponent<Collider>().enabled = false;
        if (target)
        {
            target.Damage(damage);
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}