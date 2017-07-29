using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidCharacter : AbstractCharacter {

	private bool isDead;
	public GameObject database;
	private Random random = new Random();

	// Use this for initialization
	void Start () {
		Speed = 0.3f;
		isDead = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (isDead) {
			move (-1);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Capsule") {
			Debug.Log ("Capsule detected");
		}

	}
}
