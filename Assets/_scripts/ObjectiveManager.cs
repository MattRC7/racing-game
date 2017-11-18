using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

	private Dictionary<int, Objective> objectives = new Dictionary<int, Objective>();

	public void AgentAcceptObjective (ObjectiveAgent agent, int objective_id) {
		Objective objective = objectives [objective_id];
		if (objective) {
			objective.AddAgent (agent);
		} else {
			Debug.LogWarning ("Warn: attempt to accept null objective");
		}
	}

	// Use this for initialization
	void Start () {
		// assumes any object tagged with Objective has an Objective component.
		GameObject[] objective_list = GameObject.FindGameObjectsWithTag("Objective");
		foreach (GameObject item in objective_list) {
			objectives.Add (item.GetInstanceID (), item.GetComponent<Objective> ());
		}
	}
}
