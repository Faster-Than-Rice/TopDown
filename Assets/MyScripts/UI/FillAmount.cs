using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FillAmount : MonoBehaviour
{
    [SerializeField] float startValue;
    [SerializeField] float endValue;
    [SerializeField] float duration;
    [SerializeField] float delay;
    [SerializeField] Ease ease = Ease.InOutQuad;

    private void Start()
    {
        Image image = GetComponent<Image>();
        image.fillAmount = startValue;
        image.DOFillAmount(endValue, duration).SetEase(ease).SetDelay(delay);
    }
}
