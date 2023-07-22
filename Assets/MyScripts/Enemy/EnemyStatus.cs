using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyStatus : MonoBehaviour, IDamage
{
    public int hp;
    public GameObject effect;
    public float activeDistance;
    [SerializeField] GameObject overScreen;
    [SerializeField] int scoreValue;
    GameObject instance;
    Score score;
    Combo combo;

    private void Start()
    {
        combo = GameObject.FindGameObjectWithTag("Player").GetComponent<Combo>();
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        instance = Instantiate(overScreen, transform.position, Quaternion.identity);
        instance.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        instance.GetComponent<OverScreen>().SetTarget(gameObject.transform, Camera.main);
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
            score.AddScore(scoreValue);
        }
    }

    void Destroyed()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(instance);
    }
}
