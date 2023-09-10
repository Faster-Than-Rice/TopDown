using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetObject : MonoBehaviour, IDamage
{
    [SerializeField] int hp;
    [SerializeField] int scoreValue;
    [SerializeField] GameObject effect;
    [SerializeField] UnityEvent destroyEvent;
    Score score;
    int _hp;
    bool isDestory = false;

    void Start()
    {
        _hp = hp;
        score = GameObject.Find("Player").GetComponent<Score>();
    }

    public void Damage(int value)
    {
        _hp -= value;

        if(_hp <= 0 && !isDestory)
        {
            isDestory = true;
            score.AddScore(scoreValue);
            Instantiate(effect, transform.position, Quaternion.identity);
            destroyEvent.Invoke();
            Destroy(gameObject);
        }
    }
}
