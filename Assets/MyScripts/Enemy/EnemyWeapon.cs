using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] GameObject weapon;
    [SerializeField] float range;
    [SerializeField] float speed;
    [SerializeField] float randomValue;
    EnemyStatus status;
    IWeapon iWeapon;

    private void Awake()
    {
        status = GetComponent<EnemyStatus>();
        iWeapon = weapon.GetComponent<IWeapon>();
    }

    private void FixedUpdate()
    {
        LookTarget();

        //射撃（射線・射程・角度判定）
        if (Vector3.Distance(status.target.transform.position, transform.position) <= range
            && Physics.Raycast(transform.position, status.target.transform.position - transform.position, out RaycastHit hit)
            && hit.collider.gameObject == status.target
            && Vector3.Angle(transform.forward, status.target.transform.position - transform.position) <= 30)
        {
            iWeapon.Attack();
        }
    }

    void LookTarget()
    {
        Vector3 vector3 = (new Vector3(Random.Range(0, randomValue), 0, Random.Range(0,randomValue)) 
            + status.target.transform.position) - this.transform.position;
        Quaternion quaternion = Quaternion.LookRotation(vector3);
        transform.rotation = Quaternion.Slerp(this.transform.rotation, quaternion, speed);
    }
}
