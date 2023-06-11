using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissileBullet : MonoBehaviour
{
    [SerializeField] GameObject effect;
    [SerializeField] float speed;
    [SerializeField] float torqueRatio;
    [SerializeField] int damage;
    Rigidbody rb;
    GameObject target;
    bool isFollow = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 30);
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        rb.AddForce(speed * Time.deltaTime * transform.forward);

        if (Vector3.Angle(transform.forward, target.transform.position - transform.position) >= 20)
        {
            isFollow = false;
        }

        if (isFollow)
        {
            var diff = target.transform.position - transform.position;
            var target_rot = Quaternion.LookRotation(diff);
            var rot = target_rot * Quaternion.Inverse(transform.rotation);
            if (rot.w < 0f)
            {
                rot.x = -rot.x;
                rot.y = -rot.y;
                rot.z = -rot.z;
                rot.w = -rot.w;
            }
            var torque = new Vector3(rot.x, rot.y, rot.z) * torqueRatio;
            rb.AddTorque(torque);
        }
    }

    //–½’†ˆ—
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        EnemyStatus hit = collision.gameObject.GetComponent<EnemyStatus>();
        GetComponent<Collider>().enabled = false;
        if (hit)
        {
            hit.Damage(damage);
        }
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject, GetComponent<TrailRenderer>().time);
    }
}
