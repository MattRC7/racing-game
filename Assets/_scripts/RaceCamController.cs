using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCamController : MonoBehaviour {

	public GameObject target;
	public float height;
	public float back;
	public float max_wrap;
	public float max_slide;
	public float cam_speed;

	private float offset_angle;
	private float offset_x;

	void Start() {
		offset_angle = 0.0f;
		offset_x = 0.0f;
	}

	// Update is called once per frame
	void LateUpdate () {
		float cam_wrap = cam_speed * max_wrap;
		float cam_slide = cam_speed * max_slide;
		float steering = Input.GetAxis("Horizontal");

		if (steering != 0.0f) {
			offset_angle = Mathf.Max(Mathf.Min(max_wrap,offset_angle+steering*cam_wrap*Time.deltaTime),-max_wrap);
			offset_x = Mathf.Max(Mathf.Min(max_slide,offset_x+steering*cam_slide*Time.deltaTime),-max_slide);
		}
		else {
			if (offset_angle != 0.0f) {
				offset_angle -= cam_wrap/3 * Time.deltaTime * Mathf.Abs (offset_angle) / offset_angle;
			}
			if (offset_x != 0.0f) {
				offset_x -= cam_slide/3 * Time.deltaTime * Mathf.Abs (offset_x) / offset_x;
			}
		}

		Vector3 camera_forward = Quaternion.AngleAxis(-offset_angle, target.transform.up) * target.transform.forward;
		transform.position = target.transform.position + target.transform.right*offset_x - camera_forward.normalized*back + target.transform.up*height;
		transform.rotation = Quaternion.LookRotation(camera_forward);
	}
}
