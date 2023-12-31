using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Missile : MonoBehaviour, IWeapon
{
    [SerializeField] Transform[] muzzles;
    [SerializeField] GameObject bullet;
    [SerializeField] float interval;
    [SerializeField] AudioClip clip;
    float counter;
    AudioSource source;

    private void Start()
    {
        counter = interval;
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        counter += Time.deltaTime;
    }

    public void Attack()
    {
        if (counter >= interval)
        {
            foreach(Transform muzzle in muzzles)
            {
                counter = 0;
                GameObject instance = Instantiate(bullet, muzzle.position, muzzle.rotation);
                source.PlayOneShot(clip);

                if (transform.root.CompareTag("Player"))
                {
                    if(GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
                    instance.GetComponent<MissileBullet>().SetTarget(GameObject.FindGameObjectsWithTag("Enemy")
                        .OrderBy(point => Vector3.Distance(transform.root.position, point.transform.position)).ToList()[0]);
                }
                else
                {
                    instance.GetComponent<MissileBullet>().SetTarget(GameObject.FindGameObjectWithTag("Player"));
                }
            }
        }
    }
}