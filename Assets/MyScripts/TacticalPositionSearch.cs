using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TacticalPositionSearch : MonoBehaviour
{
    [SerializeField] float maxDistance;
    List<GameObject> allPoints;

    private void Start()
    {
        allPoints = GameObject.FindGameObjectsWithTag("TacticalPoint").ToList();
    }

    public List<GameObject> Search(Transform target)
    {
        List<GameObject> points = new List<GameObject>(allPoints);
        points.RemoveAll
           (point => (point.transform.position - target.position).sqrMagnitude >= maxDistance * maxDistance
        || Physics.OverlapSphere(point.transform.position, 0).Length > 0
        || Physics.Raycast(point.transform.position, target.position - point.transform.position, out RaycastHit hit)
        && hit.collider.gameObject != target.gameObject);

        return points;
    }
}
