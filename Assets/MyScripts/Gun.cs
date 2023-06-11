using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] Transform[] muzzles;
    [SerializeField] GameObject bullet;
    [SerializeField] float interval;
    [SerializeField] float power;
    float counter;
    float nextInterval;

    private void Start()
    {
        nextInterval = interval;
        counter = nextInterval;
    }

    private void Update()
    {
        counter += Time.deltaTime;
    }

    public void Attack()
    {
        if (counter >= nextInterval)
        {
            foreach(Transform muzzle in muzzles)
            {
                counter = 0;
                nextInterval = Random.Range(interval / 1.05f, interval * 1.05f);
                GameObject _bullet = Instantiate(bullet, muzzle.position, Quaternion.Euler(Vector3.forward));
                _bullet.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * power, ForceMode.Impulse);
            }
        }
    }
}
