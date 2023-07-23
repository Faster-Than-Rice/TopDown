using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TacticalPositionSearch : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] float minDistance;
    List<GameObject> allPoints = new();

    private void Start()
    {
        allPoints = GameObject.FindGameObjectsWithTag("TacticalPoint").ToList();
    }

    public List<GameObject> Search(Transform target)
    {
        List<GameObject> points = new List<GameObject>(allPoints);
        points.RemoveAll
           (point => (point.transform.position - target.position).sqrMagnitude >= maxDistance * maxDistance
        || (point.transform.position - target.position).sqrMagnitude <= minDistance * minDistance
        || Physics.OverlapSphere(point.transform.position, 0).Length > 0
        || (Physics.Raycast(point.transform.position, target.position - point.transform.position, out RaycastHit hit)
        && hit.collider.gameObject != target.gameObject));
        points.OrderBy(point => Vector3.Distance(point.transform.position, target.transform.position));

        return points;
    }
}
