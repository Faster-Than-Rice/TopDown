using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class OperateText : MonoBehaviour
{
    [SerializeField] float duration;
    [SerializeField] float waitTime;
    [SerializeField] float moveValue;

    private void Start()
    {
        GetComponent<TextMeshProUGUI>().alpha = 0;
        Sequence sequence = DOTween.Sequence();
        sequence.Insert(0, transform.DOLocalMoveY(transform.localPosition.y + moveValue, duration));
        sequence.Insert(0, GetComponent<TextMeshProUGUI>().DOFade(1, duration));
        sequence.Insert(duration + waitTime, transform.DOLocalMoveY(transform.localPosition.y + (moveValue * 2), duration));
        sequence.Insert(duration + waitTime, GetComponent<TextMeshProUGUI>().DOFade(0, duration));
        sequence.Play();
    }
}
