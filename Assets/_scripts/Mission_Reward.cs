using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_Reward : MonoBehaviour {

	public int credit_reward;

	public void giveReward(Player player) {
		player.addCredits(credit_reward);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
