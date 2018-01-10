using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public Checkpoint next;
	private Mission_Reward reward;

	// Use this for initialization
	void Start () {
		reward = GetComponent<Mission_Reward>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Player player = other.GetComponent<Player>();
		if (player) {
			if (next) {
				next.gameObject.SetActive(true);
			}
			if (reward) {
				reward.giveReward(player);
			}
			gameObject.SetActive(false);
		}
	}
}
