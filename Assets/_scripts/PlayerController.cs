using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float thrust;
	public float spin;
	public Text countText;

	private Rigidbody rb;
	private int currency;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		currency = 0;
		countText.text = "Currency: " + currency.ToString();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float accelerator = Input.GetAxis("Vertical");
		float turn = Input.GetAxis("Horizontal");
		rb.AddForce(transform.forward * accelerator * thrust * Time.deltaTime);
		rb.AddTorque(transform.up * turn * spin * Time.deltaTime);
	}
}
