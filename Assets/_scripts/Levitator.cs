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
		bool at_hover_distance = this.isAtOrBelowHoverDistance();
		if (fall_speed <= -max_fall_speed || at_hover_distance) {
			this.AddAntiGravityForce();
		}
		if (fall_speed < 0 && at_hover_distance) {
			rb.AddForce(-Vector3.Project(rb.velocity, Physics.gravity), ForceMode.VelocityChange);
		}

		this.StabilizeRotation(transform.forward, transform.rotation.z);
		this.StabilizeRotation(transform.right, transform.rotation.x);
	}

	void StabilizeRotation (Vector3 rotation_vector, float current_value) {
		if (Mathf.Abs(current_value) > 0.01f) {
			float current_speed = Vector3.Project(rb.angularVelocity, rotation_vector).magnitude;
			if (current_value > 0 && current_speed > -1) {
				rb.AddTorque(-rotation_vector);
			}
			else if (current_value < 0 && current_speed < 1) {
				rb.AddTorque(rotation_vector);
			}
		}
		else {
			rb.AddTorque(-Vector3.Project(rb.angularVelocity, rotation_vector), ForceMode.VelocityChange);
		}
	}

	bool isAtOrBelowHoverDistance () {
		return Physics.Raycast(transform.position, -transform.up, hover_height);
	}

	void AddAntiGravityForce() {
		rb.AddForce(-Physics.gravity);
	}
}
