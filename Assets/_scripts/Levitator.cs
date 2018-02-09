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
	
	void FixedUpdate () {
		Vector3 fall_velocity = Vector3.Project(rb.velocity, Physics.gravity);
		float fall_speed = -Mathf.Sign(Vector3.Dot(fall_velocity, Physics.gravity))*fall_velocity.magnitude;
		float current_height = this.currentDistanceAboveFloor();
		float next_step_height = current_height + (fall_speed * Time.deltaTime);
		float target_height_delta = hover_height - current_height;
		Debug.Log("current_height: "+current_height);
		Debug.Log("fall speed: "+fall_speed);
		Debug.Log("next step height: "+next_step_height);
		Debug.Log("target_height_delta: "+target_height_delta);

		float target_speed;
		if (target_height_delta == 0) {
			target_speed = 0;
		}
		else if (Mathf.Sign(current_height - hover_height) != Mathf.Sign(next_step_height - hover_height)) {
			target_speed = target_height_delta / Time.deltaTime;
 		}
		else if (target_height_delta > 0) {
			target_speed = Physics.gravity.magnitude;
		}
		else {
			target_speed = -max_fall_speed;
		}
		Debug.Log("target_speed: "+target_speed);

		float max_accel = 3.0f;
		float target_speed_delta = target_speed - fall_speed;
		float next_step_speed = fall_speed + max_accel*Mathf.Sign(target_speed_delta)*Time.deltaTime;
		Debug.Log("target_speed_delta: "+target_speed_delta);
		Debug.Log("next step speed: "+next_step_speed);
		if (Mathf.Sign(current_height - hover_height) != Mathf.Sign(next_step_height - hover_height)) {
			this.AddAntiGravityForce();
			rb.AddForce(-Physics.gravity.normalized*target_speed_delta, ForceMode.VelocityChange);
		}
		else if (target_speed_delta > 0) {
			this.AddAntiGravityForce();
			rb.AddForce(-Physics.gravity.normalized*max_accel);
		}

		this.StabilizeRotation(transform.forward, transform.rotation.z);
		this.StabilizeRotation(transform.right, transform.rotation.x);
	}

	void StabilizeRotation (Vector3 rotation_vector, float current_value) {
		Vector3 current_velocity = Vector3.Project(rb.angularVelocity, rotation_vector);
		if (current_value == 0) {
			rb.AddTorque(-current_velocity, ForceMode.VelocityChange);
		}
		else {
			float current_speed = Mathf.Sign(Vector3.Dot(current_velocity, rotation_vector))*current_velocity.magnitude;
			bool same_speed_sign_as_value = Mathf.Sign(current_value) == Mathf.Sign(current_speed);

			if (!same_speed_sign_as_value && Mathf.Abs(current_value) < Mathf.Abs(current_speed * Time.deltaTime)) {
				rb.AddTorque(-rotation_vector*(current_speed+(current_value/Time.deltaTime)),ForceMode.VelocityChange);
			}
			else if (same_speed_sign_as_value || Mathf.Abs(current_speed) < 3) {
				rb.AddTorque(-(Mathf.Sign(current_value))*3*rotation_vector);
			}
		}
	}

	float currentDistanceAboveFloor () {
		RaycastHit hit;
		Physics.Raycast(transform.position, -transform.up, out hit);
		return hit.distance;
	}

	void AddAntiGravityForce() {
		rb.AddForce(-Physics.gravity);
	}
}
