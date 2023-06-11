using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TacticalPositionSearch : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;

    public GameObject Search(Transform target, bool isHide, bool isMax)
    {
        List<GameObject> points = new();

        points = GameObject.FindGameObjectsWithTag("TacticalPoint").ToList();

        points.RemoveAll(point => (point.transform.position - target.position).sqrMagnitude <= minDistance * minDistance
        || (point.transform.position - target.position).sqrMagnitude >= maxDistance * maxDistance
        || Physics.OverlapSphere(point.transform.position, 0).Length > 0);

        if (isHide)
        {
            points.RemoveAll(point =>
            Physics.Raycast(point.transform.position, target.position - point.transform.position, out RaycastHit hit)
            && hit.collider.gameObject == target.gameObject);
        }
        else
        {
            points.RemoveAll(point =>
           Physics.Raycast(point.transform.position, target.position - point.transform.position, out RaycastHit hit)
           && hit.collider.gameObject != target.gameObject);
        }

        if (isMax)
        {
            points = points.OrderByDescending(point => Vector3.Distance(target.position, point.transform.position)).ToList();
        }
        else
        {
            points = points.OrderBy(point => Vector3.Distance(target.position, point.transform.position)).ToList();
        }

        if(points.Count == 0)
        {
            return null;   
        }
        else
        {
            return points[Random.Range(0, points.Count - 1)];
        }
    }
}
