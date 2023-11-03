using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    WeaponData[] weapons;
    GameObject weaponObject;
    IWeapon weapon;
    int changeNumber = 1;

    private void Start()
    {
        weapons = Resources.Load<Equipped>("Weapon").weapons.ToArray();
        weaponObject = Instantiate(weapons[0].weaponObject, transform.position, Quaternion.identity);
        weaponObject.transform.SetParent(transform);
        weaponObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
        weapon = weaponObject.GetComponent<IWeapon>();
    }

    private void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        //ŽËŒ‚
        if (Input.GetMouseButton(0))
        {
            weapon.Attack();
        }

        //•‘••ÏX
        if(Input.GetMouseButtonDown(1))
        {
            changeNumber++;
            if(changeNumber > weapons.Length)
            {
                changeNumber = 1;
            }
            Destroy(weaponObject);
            weaponObject = Instantiate(weapons[changeNumber - 1].weaponObject, transform.position, Quaternion.identity);
            weaponObject.transform.SetParent(transform);
            weaponObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            weapon = weaponObject.GetComponent<IWeapon>();
        }

        Cursor.lockState = CursorLockMode.Confined;
    }
}
