using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int credits;

	public void addCredits(int count) {
		credits += count;
		Debug.Log(credits);
	}

	// Use this for initialization
	void Start () {
		credits = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
