using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IWeapon
{
    [SerializeField] Transform[] muzzles;
    [SerializeField] GameObject bullet;
    [SerializeField] float interval;
    float counter;

    private void Start()
    {
        counter = interval;
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
                instance.GetComponent<MissileBullet>().SetTarget(GameObject.FindGameObjectWithTag("Player"));
            }
        }
    }
}