﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DroidCharacter : AbstractCharacter {

	private bool isDead;
	private bool hasJobAssigned;
	private bool isGoingToDatabase;
	public GameObject database;
	private int direction;
	private System.Random random = new System.Random();

	// Use this for initialization
	void Start () {
		Speed = 0;
		isDead = true;
		hasJobAssigned = false;
		isGoingToDatabase = false;
		direction = -1;
		Debug.Log (direction);
	}
	
	// Update is called once per frame
	void Update () {
				
		if (isGoingToDatabase) {

			if (gameObject.transform.position.x > database.transform.position.x) {
				move (-1);
			} else {
				move (1);
			}
		} else {
			move (direction);
		}
			
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Capsule" && !hasJobAssigned && !isGoingToDatabase) {
			Destroy (coll.gameObject);
			isGoingToDatabase = true;
			Debug.Log ("Capsule detected");
		}

		if (coll.gameObject.tag == "Database" && isGoingToDatabase) {
			CapsuleStore.AddCapsule ();
			isGoingToDatabase = false;
			//direction = getRandomDirection ();
			Debug.Log ("Added Capsule");
		}
	}

	private int getRandomDirection() {
		return random.NextDouble () > 0.5 ? -1 : 1;
	}
}
