using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour {
	public Checkpoint [] starting_checkpoints;

	// Use this for initialization
	void Start () {
		Debug.Log(starting_checkpoints.GetUpperBound(0));
		starting_checkpoints[Random.Range(0,starting_checkpoints.Length)].gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
