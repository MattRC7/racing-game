﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitator : MonoBehaviour {
	public float max_fall_speed;
	public float hover_height;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
		Vector3 target_point = this.floorPoint() + -Physics.gravity.normalized*hover_height;
		Vector3 point_delta = target_point - transform.position;

		float max_speed = Vector3.Dot(point_delta, Physics.gravity) > 0 ? max_fall_speed : 15.0f;
		float target_speed = point_delta.magnitude < max_speed * Time.deltaTime
			? 0.5f * point_delta.magnitude / Time.deltaTime
			: max_speed;
		ForceMode mode = target_speed > 0 && target_speed < max_speed
			? ForceMode.VelocityChange
			: ForceMode.Acceleration;

		Vector3 target_velocity = point_delta.normalized*target_speed;
		Vector3 current_velocity = Vector3.Project(rb.velocity, -Physics.gravity);
		Vector3 velocity_delta = target_velocity - current_velocity;

		Vector3	total_acceleration = velocity_delta - Physics.gravity*(mode == ForceMode.VelocityChange ? Time.deltaTime : 1);

		rb.AddForce(total_acceleration, mode);

		Vector3 current_rotation = transform.up;
		Vector3 target_rotation = Vector3.up;
		Vector3 rotation_plane = Vector3.Cross(current_rotation, target_rotation).normalized;

		Vector3 current_angular_velocity = rb.angularVelocity;
		Vector3 target_angular_velocity = rotation_plane*Mathf.PI;
		Vector3 angular_velocity_delta = target_angular_velocity - current_angular_velocity.normalized*2.0f;

		rb.AddTorque(angular_velocity_delta, ForceMode.Acceleration);
	}

	Vector3 floorPoint () {
		RaycastHit hit;
		Physics.Raycast(transform.position, -Vector3.up, out hit);
		return hit.point;
	}

	void AddAntiGravityForce() {
		rb.AddForce(-Physics.gravity);
	}
}
