using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public int hp;
    [System.NonSerialized] public GameObject target;
    public GameObject effect;
    public float activeDistance;
    Combo combo;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        combo = GameObject.FindGameObjectWithTag("Player").GetComponent<Combo>();
    }

    //ダメージ処理（外部実行）
    public void Damage(int damageValue)
    {
        hp -= damageValue;

        //撃破処理
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
