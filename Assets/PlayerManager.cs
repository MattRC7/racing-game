using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public Player player_component;

	// Use this for initialization
	void Start () {
		Instantiate(player_component, Vector3.zero, Quaternion.identity);
	}
}
