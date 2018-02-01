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
		if (fall_speed <= -max_fall_speed || height <= hover_height) {
			this.AddAntiGravityForce();
		}
		if (fall_speed < 0 && height <= hover_height) {
			rb.AddForce(-Vector3.Project(rb.velocity, Physics.gravity), ForceMode.VelocityChange);
		}
	}

	void AddAntiGravityForce() {
		rb.AddForce(-Physics.gravity);
	}
}
