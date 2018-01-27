using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float thrust;
	public float spin;
	public float grip;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float accelerator = Input.GetAxis("Vertical");
		float turn = Input.GetAxis("Horizontal");
		Vector3 lateral_velocity = this.LateralVelocity();
		float friction = Mathf.Min(lateral_velocity.magnitude, grip * Time.deltaTime);
		rb.AddForce(transform.forward * accelerator * thrust * Time.deltaTime);
		rb.AddTorque(transform.up * turn * spin * Time.deltaTime);
		rb.AddForce(-lateral_velocity * friction);
	}

	Vector3 LateralVelocity () {
		return Vector3.Project(rb.velocity, transform.right);
	}
}
