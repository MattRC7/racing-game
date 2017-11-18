using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveAgent : MonoBehaviour {
	public Text targetText;

	private ObjectiveManager manager;
	private Goal current_goal;

	public void AddGoal (Goal goal) {
		current_goal = goal;
	}

	void Start() {
		manager = GameObject.FindObjectOfType<ObjectiveManager>();
	}

	void Update() {
		if (current_goal != null) {
			float distance_to_target = Vector3.Distance (transform.position, current_goal.GetLocation ());
			targetText.text = "Distance to target: "+distance_to_target.ToString();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		manager.AgentAcceptObjective (this, other.gameObject.GetInstanceID ());
	}
}
