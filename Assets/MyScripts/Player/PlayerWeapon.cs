using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    GameObject weaponObject;
    IWeapon weapon;
    int changeNumber = 1;

    private void Start()
    {
        weaponObject = Instantiate(weapons[0], transform.position, Quaternion.identity);
        weaponObject.transform.SetParent(transform);
        weaponObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
        weapon = weaponObject.GetComponent<IWeapon>();
    }

    private void Update()
    {
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
            weaponObject = Instantiate(weapons[changeNumber - 1], transform.position, Quaternion.identity);
            weaponObject.transform.SetParent(transform);
            weaponObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            weapon = weaponObject.GetComponent<IWeapon>();
        }

        Cursor.lockState = CursorLockMode.Confined;
    }
}
