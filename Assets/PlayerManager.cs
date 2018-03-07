using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public Player player_component;

	private Player[] players = new Player[4];

	// Use this for initialization
	void Start () {
		Instantiate(player_component, new Vector3(3, 4, 3), Quaternion.identity);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			Instantiate(player_component, new Vector3(3, 4, -3), Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			Instantiate(player_component, new Vector3(-3, 4, 3), Quaternion.identity);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			Instantiate(player_component, new Vector3(-3, 4, -3), Quaternion.identity);
		}
	}
}
