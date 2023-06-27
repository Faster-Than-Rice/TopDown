using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int hp;
    public GameObject effect;
    public float activeDistance;
    Combo combo;

    private void Start()
    {
        combo = GameObject.FindGameObjectWithTag("Player").GetComponent<Combo>();
    }

    //�_���[�W�����i�O�����s�j
    public void Damage(int damageValue)
    {
        hp -= damageValue;

        //���j����
        if (hp <= 0)
        {
            Destroyed();
            combo.Add();
        }
    }

    void Destroyed()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
