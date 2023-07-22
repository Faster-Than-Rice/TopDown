using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShake : MonoBehaviour
{
    [SerializeField] float shake;
    [SerializeField] float time;
    PlayerCamera cam;

    private void Awake()
    {
        cam = Camera.main.GetComponent<PlayerCamera>();
    }

    public void Shake()
    {
        cam.Shake(shake, time);
    }
}
