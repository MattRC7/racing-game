using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Goal : MonoBehaviour {

	public int credit_reward;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		Player player = other.GetComponent<Player>();
		if (player) {
			player.addCredits(credit_reward);
		}
	}
}
