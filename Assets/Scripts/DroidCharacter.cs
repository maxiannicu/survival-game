﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidCharacter : AbstractCharacter {

	private bool isWorking;

	// Use this for initialization
	void Start () {
		Speed = 0.3f;
		isWorking = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (isWorking) {
			move (-1);
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log ("Hello");
		Destroy (collider.gameObject);
	}
}
