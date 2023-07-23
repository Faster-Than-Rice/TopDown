using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;

public class PlayerDamage : MonoBehaviour, IDamage
{
    [SerializeField] float maxHitPoint;
    [SerializeField] Slider bar;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float recoveryTime;
    [SerializeField] UnityEvent gameOverEvent;
    [SerializeField] GameObject fade;
    float hitPoint;
    float recoveryCount;

    private void Start()
    {
        recoveryCount = recoveryTime;
        hitPoint = maxHitPoint;
        text.text = "100%";
        bar.value = 1;
    }

    public void Damage(int damageValue)
    {
        hitPoint -= damageValue;
        text.text = ((hitPoint / maxHitPoint) * 100).ToString("f0") + "%";
        bar.value = hitPoint / maxHitPoint;
        recoveryCount = recoveryTime;
        hitPoint = Mathf.Clamp(hitPoint, 0, maxHitPoint);

        if(hitPoint <= 0)
        {
            GameOver();
        }
    }

    private void FixedUpdate()
    {
        recoveryCount -= Time.deltaTime;

        if(recoveryCount <= 0)
        {
            hitPoint += 0.25f;
            text.text = ((hitPoint / maxHitPoint) * 100).ToString("f0") + "%";
            bar.value = hitPoint / maxHitPoint;
        }
    }

    void GameOver()
    {
        Result.score = GetComponent<Score>().scoreCounter;
        gameOverEvent.Invoke();
        Invoke(new Action(() => fade.GetComponent<DOTweenAnimation>().DOPlayBackwards()).Method.Name, 2);
    }

    void LateUpdate()
    {
        hitPoint = Mathf.Clamp(hitPoint, 0, maxHitPoint);
    }
}