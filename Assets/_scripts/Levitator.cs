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
	}

	bool isAtOrBelowHoverDistance () {
		return Physics.Raycast(transform.position, -transform.up, hover_height);
	}

	void AddAntiGravityForce() {
		rb.AddForce(-Physics.gravity);
	}
}
