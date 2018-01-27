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
		this.AddForwardThrust();
		this.AddTurnTorque();
		this.AddLateralFriction();
	}

	void AddForwardThrust() {
		float accelerator = Input.GetAxis("Vertical");
		rb.AddForce(transform.forward * accelerator * thrust * Time.deltaTime);
	}

	void AddTurnTorque () {
		float turn = Input.GetAxis("Horizontal");
		rb.AddTorque(transform.up * turn * spin * Time.deltaTime);
	}

	void AddLateralFriction() {
		Vector3 lateral_velocity = this.LateralVelocity();
		float friction = Mathf.Min(lateral_velocity.magnitude, grip * Time.deltaTime);
		rb.AddForce(-lateral_velocity * friction);
	}

	Vector3 LateralVelocity () {
		return Vector3.Project(rb.velocity, transform.right);
	}
}
