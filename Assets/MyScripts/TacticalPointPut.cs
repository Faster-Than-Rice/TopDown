using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticalPointPut : MonoBehaviour
{
    [SerializeField] GameObject pointObject;
    [SerializeField] float interval;
    [SerializeField] int number;

    List<GameObject> points;

    [ContextMenu("Put")]
    void Put()
    {
        foreach (Vector3 point in MyUtility.Grid(transform.position, interval, number))
        {
            GameObject _point = Instantiate(pointObject, point, Quaternion.identity);
            _point.transform.SetParent(transform);
            points.Add(_point);
        }
    }

    [ContextMenu("Clear")]
    void Clear()
    {
        if(points.Count != 0)
        points.Clear();
    }
}
