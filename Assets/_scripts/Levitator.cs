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
		Vector3 current_velocity = Vector3.Project(rb.angularVelocity, rotation_vector);
		Debug.Log("current value: "+current_value);
		if (current_value == 0) {
			Debug.Log("zeroing out velocity");
			rb.AddTorque(-current_velocity, ForceMode.VelocityChange);
		}
		else {
			float current_speed = Mathf.Sign(Vector3.Dot(current_velocity, rotation_vector))*current_velocity.magnitude;
			Debug.Log("current speed: "+current_speed);
			bool same_speed_sign_as_value = Mathf.Sign(current_value) == Mathf.Sign(current_speed);

			if (!same_speed_sign_as_value && Mathf.Abs(current_value) < Mathf.Abs(current_speed * Time.deltaTime)) {
				Debug.Log("fine-tuning velocity");
				rb.AddTorque(-rotation_vector*(current_speed+(current_value/Time.deltaTime)),ForceMode.VelocityChange);
			}
			else if (same_speed_sign_as_value || Mathf.Abs(current_speed) < 3) {
				Debug.Log("changing velocity");
				rb.AddTorque(-(Mathf.Sign(current_value))*rotation_vector);
			}
		}
	}

	bool isAtOrBelowHoverDistance () {
		return Physics.Raycast(transform.position, -transform.up, hover_height);
	}

	void AddAntiGravityForce() {
		rb.AddForce(-Physics.gravity);
	}
}
