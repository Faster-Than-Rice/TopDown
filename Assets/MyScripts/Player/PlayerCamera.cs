using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 random = Vector3.zero;
    float t = 1;

    private void LateUpdate()
    {
        transform.position = 
            Vector3.Slerp(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z) + random, t);
    }

    public void Shake(float shake, float time)
    {
        StartCoroutine(DoShake(shake, time));
    }

    IEnumerator DoShake(float shake, float time)
    {
        
        for(int counter = 0;counter <= ((int)(time * 10)) ; counter++)
        {
            random = new Vector3(Random.Range(0, shake), 0, Random.Range(0, shake));
            yield return new WaitForSeconds(0.05f);
            random = Vector3.zero;
        }
    }
}
