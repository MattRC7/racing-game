using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

	private Dictionary<int, ObjectiveAgent> active_agents = new Dictionary<int, ObjectiveAgent>();
	private Goal goal;

	public void AddAgent(ObjectiveAgent agent) {
		int agent_id = agent.gameObject.GetInstanceID ();
		if (!active_agents.ContainsKey(agent_id)) {
			active_agents.Add (agent_id, agent);
			agent.AddGoal(goal);
		}
		Debug.Log ("Objective #" + gameObject.GetInstanceID () + " added Agent #" + agent_id);
	}

	// Use this for initialization
	void Start () {
		if (gameObject.tag != "Objective") {
			Debug.LogError ("Object with Objective script not tagged as Objective");
		}
		goal = new Goal (new Vector3 (1, 1, 1));
	}
}

public class Goal {
	private Vector3 location;

	public Goal (Vector3 init_location) {
		location = init_location;
	}

	public Vector3 GetLocation() {
		return location;
	}
}