using System.Collections;
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
	
	// Update is called once per frame
	void FixedUpdate () {
		float fall_speed = -Vector3.Project(rb.velocity, Physics.gravity).magnitude;
		float height = transform.position.y;
		bool at_hover_distance = this.isAtOrBelowHoverDistance();
		if (fall_speed <= -max_fall_speed || at_hover_distance) {
			this.AddAntiGravityForce();
		}
		if (fall_speed < 0 && at_hover_distance) {
			rb.AddForce(-Vector3.Project(rb.velocity, Physics.gravity), ForceMode.VelocityChange);
		}

		float current_roll = transform.rotation.z;
		if (Mathf.Abs(current_roll) > 0.01f) {
			float current_roll_speed = Vector3.Project(rb.angularVelocity, transform.forward).magnitude;
			if (current_roll > 0 && current_roll_speed > -1) {
				rb.AddTorque(-transform.forward);
			}
			else if (current_roll < 0 && current_roll_speed < 1) {
				rb.AddTorque(transform.forward);
			}
		}
		else {
			rb.AddTorque(-Vector3.Project(rb.angularVelocity, transform.forward), ForceMode.VelocityChange);
		}

		float current_pitch = transform.rotation.x;
		if (Mathf.Abs(current_pitch) > 0.01f) {
			float current_pitch_speed = Vector3.Project(rb.angularVelocity, transform.right).magnitude;
			if (current_pitch > 0 && current_pitch_speed > -1) {
				rb.AddTorque(-transform.right);
			}
			else if (current_pitch < 0 && current_pitch_speed < 1) {
				rb.AddTorque(transform.right);
			}
		}
		else {
			rb.AddTorque(-Vector3.Project(rb.angularVelocity, transform.right), ForceMode.VelocityChange);
		}
	}

	bool isAtOrBelowHoverDistance () {
		return Physics.Raycast(transform.position, -transform.up, hover_height);
	}

	void AddAntiGravityForce() {
		rb.AddForce(-Physics.gravity);
	}
}
