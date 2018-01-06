using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Text countText;

	private int credits;

	public void addCredits(int count) {
		credits += count;
		countText.text = "Currency: " + credits.ToString();
	}

	// Use this for initialization
	void Start () {
		credits = 0;
		countText.text = "Currency: " + credits.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
