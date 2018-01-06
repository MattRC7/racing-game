using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float thrust;
	public float spin;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float accelerator = Input.GetAxis("Vertical");
		float turn = Input.GetAxis("Horizontal");
		rb.AddForce(transform.forward * accelerator * thrust * Time.deltaTime);
		rb.AddTorque(transform.up * turn * spin * Time.deltaTime);
	}
}
