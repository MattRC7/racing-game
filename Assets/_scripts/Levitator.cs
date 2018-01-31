using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitator : MonoBehaviour {
	public float max_fall_speed;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float fall_speed = -Vector3.Project(rb.velocity, Physics.gravity).magnitude;
		if (fall_speed <= -max_fall_speed) {
			this.AddAntiGravityForce();
		}
	}

	void AddAntiGravityForce() {
		rb.AddForce(-Physics.gravity);
	}
}
