using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	[SerializeField] float speed;
	Plane plane = new Plane();
	float distance = 0;
	Rigidbody rb;

    private void Start()
    {
		rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
	{
		rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);

		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
		if (plane.Raycast(ray, out distance))
		{
			var lookPoint = ray.GetPoint(distance);
			transform.LookAt(lookPoint);
		}
	}
}
