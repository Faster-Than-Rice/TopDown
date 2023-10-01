using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] List<GameObject> weapons;
    [SerializeField] LayerMask mask;
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] float randomValue;
    EnemyStatus status;
    List<IWeapon> iWeapons = new();
    GameObject target;

    private void Awake()
    {
        status = GetComponent<EnemyStatus>();
        foreach(GameObject weapon in weapons)
        {
            iWeapons.Add(weapon.GetComponent<IWeapon>());
        }
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        //射撃（射線・射程・角度判定）
        if (Vector3.Distance(target.transform.position, transform.position) <= range
            && Physics.Raycast(transform.position, target.transform.position - transform.position, out RaycastHit hit, mask)
            && hit.collider.gameObject == target
            && Vector3.Angle(transform.forward, target.transform.position - transform.position) <= 30)
        {
            foreach(IWeapon weapon in iWeapons)
            {
                weapon.Attack();
            }
        }
    }

    private void LateUpdate()
    {
        LookTarget();
    }

    void LookTarget()
    {
        Vector3 vector3 = target.transform.position - this.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, speed);
    }
}
