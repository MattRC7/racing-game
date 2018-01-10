using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCompleter : MonoBehaviour {

	public MissionController controller;

	public void missionComplete () {
		controller.missionComplete();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
