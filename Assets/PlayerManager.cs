using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public Player player_component;
	public PlayerRaceCamController camera_component;

	private Player[] players = new Player[4];
	private PlayerRaceCamController[] cameras = new PlayerRaceCamController[4];

	// Use this for initialization
	void Start () {
		AddPlayer(1, new Vector3(4,4,4));
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			RemovePlayer(2);
			RemovePlayer(3);
			RemovePlayer(4);
			SplitScreen();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			AddPlayer(2, new Vector3(4, 4, -4));
			RemovePlayer(3);
			RemovePlayer(4);
			SplitScreen();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			AddPlayer(2, new Vector3(4, 4, -4));
			AddPlayer(3, new Vector3(-4, 4, 4));
			RemovePlayer(4);
			SplitScreen();
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			AddPlayer(2, new Vector3(4, 4, -4));
			AddPlayer(3, new Vector3(-4, 4, 4));
			AddPlayer(4, new Vector3(-4, 4, -4));
			SplitScreen();
		}
	}

	void SplitScreen () {
		Rect[] viewports;
		int camera_count = CameraCount();
		if (camera_count == 1) {
			viewports = new Rect[] { new Rect(0.0f,0.0f,1.0f,1.0f) };
		}
		else if (camera_count == 2) {
			viewports = new Rect[] { new Rect(0.0f,0.0f,0.5f,1.0f), new Rect(0.5f,0.0f,0.5f,1.0f) };
		}
		else {
			viewports = new Rect[] {
				new Rect(0.0f,0.0f,0.5f,0.5f),
				new Rect(0.5f,0.0f,1.0f,0.5f),
				new Rect(0.0f,0.5f,0.5f,1.0f),
				new Rect(0.5f,0.5f,1.0f,1.0f)
			};
		}

		int next_viewport = 0;
		for (int i=0; i < cameras.Length; i++) {
			if (cameras[i]) {
				cameras[i].GetComponent<Camera>().rect = viewports[next_viewport];
				next_viewport += 1;
			}
		}
	}

	int CameraCount () {
		int count = 0;
		foreach (PlayerRaceCamController camera in cameras) {
			count = camera ? count + 1 : count;
		}
		return count;
	}

	void AddPlayer (int number, Vector3 position) {
		if (number >= 1 && number <= 4 && !players[number - 1]) {
			players[number - 1] = Instantiate(player_component, position, Quaternion.identity).GetComponent<Player>();
			cameras[number - 1] = Instantiate(camera_component, Vector3.zero, Quaternion.identity).GetComponent<PlayerRaceCamController>();
			cameras[number - 1].target = players[number - 1];
		}
	}

	void RemovePlayer (int number) {
		if (number >= 1 && number <= 4 && players[number - 1]) {
			Destroy(players[number - 1].gameObject);
			Destroy(cameras[number - 1].gameObject);
			players[number - 1] = null;
			cameras[number - 1] = null;
		}
	}
}
