using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public Player player_component;

	private Player[] players = new Player[4];

	// Use this for initialization
	void Start () {
		AddPlayer(1, new Vector3(4,4,4));
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			RemovePlayer(2);
			RemovePlayer(3);
			RemovePlayer(4);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			AddPlayer(2, new Vector3(4, 4, -4));
			RemovePlayer(3);
			RemovePlayer(4);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			AddPlayer(2, new Vector3(4, 4, -4));
			AddPlayer(3, new Vector3(-4, 4, 4));
			RemovePlayer(4);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			AddPlayer(2, new Vector3(4, 4, -4));
			AddPlayer(3, new Vector3(-4, 4, 4));
			AddPlayer(4, new Vector3(-4, 4, -4));
		}
	}

	void AddPlayer (int number, Vector3 position) {
		if (number >= 1 && number <= 4 && !players[number - 1]) {
			players[number - 1] = Instantiate(player_component, position, Quaternion.identity).GetComponent<Player>();
		}
	}

	void RemovePlayer (int number) {
		if (number >= 1 && number <= 4 && players[number - 1]) {
			Destroy(players[number - 1].gameObject);
		}
	}
}
