using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineOfFire : MonoBehaviour
{
    LineRenderer line;
    [SerializeField] LayerMask mask;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Infinity, mask))
        {
            line.SetPositions(new Vector3[] { transform.position, hit.point });
        }
        else
        {
            line.SetPositions(new Vector3[] { transform.position, transform.position + transform.forward * 1000 });
        }
    }
}
