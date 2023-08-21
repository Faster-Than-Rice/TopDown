using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Gate : MonoBehaviour
{
    [SerializeField] DOTweenAnimation gate1;
    [SerializeField] DOTweenAnimation gate2;
    [SerializeField] AudioClip clip;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Open()
    {
        gate1.DOPlayForward();
        gate2.DOPlayForward();
        source.PlayOneShot(clip);
    }

    public void Close()
    {
        gate1.DOPlayBackwards();
        gate2.DOPlayBackwards();
        source.PlayOneShot(clip);
    }
}