using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour, IWeapon
{
    [SerializeField] Transform[] muzzles;
    [SerializeField] GameObject bullet;
    [SerializeField] float interval;
    [SerializeField] float power;
    [SerializeField] UnityEvent attackEvent;
    [SerializeField] AudioClip clip;
    float counter;
    float nextInterval;
    AudioSource source;

    private void Start()
    {
        nextInterval = interval;
        counter = 0;
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        counter += Time.deltaTime;
    }

    public void Attack()
    {
        if (counter >= nextInterval)
        {
            attackEvent.Invoke();
            foreach(Transform muzzle in muzzles)
            {
                source.PlayOneShot(clip);
                counter = 0;
                nextInterval = Random.Range(interval / 1.05f, interval * 1.05f);
                GameObject _bullet = Instantiate(bullet, muzzle.position, Quaternion.Euler(Vector3.forward));
                _bullet.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * power, ForceMode.Impulse);
            }
        }
    }
}
