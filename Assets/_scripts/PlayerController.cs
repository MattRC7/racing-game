﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float thrust;
	public float spin;
	public float grip;
	public float handling;

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
		Vector3 angular_lateral_velocity = Vector3.Project(rb.angularVelocity, transform.up);
		if (Mathf.Abs(turn) > 0.1f) {
			float fractional_angular_velocity = Mathf.Pow((1.0f - angular_lateral_velocity.magnitude/4.0f), 2);
			rb.AddTorque(transform.up * turn * spin * Time.deltaTime * fractional_angular_velocity);
		}
		else {
			float angular_friction = Mathf.Min(angular_lateral_velocity.magnitude * Mathf.Rad2Deg, handling * Time.deltaTime);
			rb.AddTorque(-angular_lateral_velocity.normalized * angular_friction);
		}
	}

	void AddLateralFriction() {
		Vector3 lateral_velocity = this.LateralVelocity();
		float friction = Mathf.Min(lateral_velocity.magnitude, grip * Time.deltaTime);
		rb.AddForce(-lateral_velocity.normalized * friction);
	}

	Vector3 LateralVelocity () {
		return Vector3.Project(rb.velocity, transform.right);
	}
}
