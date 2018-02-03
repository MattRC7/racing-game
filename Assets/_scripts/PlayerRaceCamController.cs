using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaceCamController : MonoBehaviour {
	public GameObject target;
	public float height;
	public float back;
	public float forward;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = cameraPosition();
		transform.rotation = cameraRotation();
	}
	
	Vector3 effectiveForward () {
		return Vector3.ProjectOnPlane(target.transform.forward, Vector3.up);
	}
	Vector3 lookDirection () {
		return target.transform.position + effectiveForward()*forward - cameraPosition();
	}
	Vector3 cameraPosition () {
		return target.transform.position - effectiveForward()*back + Vector3.up*height;
	}
	Quaternion cameraRotation () {
		return Quaternion.LookRotation(lookDirection());
	}
}
