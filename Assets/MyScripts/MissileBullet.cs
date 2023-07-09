using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissileBullet : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] float speed;
    [SerializeField] float limit;
    [SerializeField] int damage;
    [SerializeField] float randomValue;
    [SerializeField] float unLockAngle;
    Rigidbody rb;
    GameObject target;
    bool isFollow = true;
    bool isHit = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = Random.Range(0f, 1f);
        speed = Random.Range(speed / 2, speed * 2);
        Invoke(nameof(Hit), 60);
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    { 
        if(target == null)
        {
            Hit();
        }
        else if (rb.velocity.magnitude <= limit)
        {
            rb.AddForce(speed * Time.deltaTime 
                * (target.transform.position 
                + new Vector3(Random.Range(0, randomValue), 0, Random.Range(0, randomValue)) - transform.position).normalized);
        }
    }

    //–½’†ˆ—
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        IDamage hit = collision.gameObject.GetComponent<IDamage>();
        GetComponent<Collider>().enabled = false;
        if (hit != null)
        {
            hit.Damage(damage);
        }
        Hit();
    }

    void Hit()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject, GetComponent<TrailRenderer>().time);
    }
}
