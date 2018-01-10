using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour {
	public Checkpoint [] starting_checkpoints;

	public void missionComplete () {
		activateMission();
	}

	// Use this for initialization
	void Start () {
		for (int i=0; i < starting_checkpoints.Length; i++) {
			MissionCompleter new_completer = starting_checkpoints[i].last().gameObject.AddComponent<MissionCompleter>();
			new_completer.controller = this;
		}
		activateMission();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void activateMission () {
		starting_checkpoints[Random.Range(0,starting_checkpoints.Length)].gameObject.SetActive(true);
	}
}
