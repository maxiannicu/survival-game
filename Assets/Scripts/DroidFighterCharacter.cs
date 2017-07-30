using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidFighterCharacter : AbstractCharacter {
	private UpgradableComponent _upgradableComponent;
	private int direction;

	// Use this for initialization
	void Start () {
		_upgradableComponent = GetComponent<UpgradableComponent> ();
		SetIdle (true);
		direction = -1;
	}
	
	// Update is called once per frame
	void Update () {
		SetIdle (!_upgradableComponent.IsPurchased);
		moveUp ();
		if (gameObject.transform.position.x > 0) {
			move (-1);
		} else {
			move (1);
		}

	}

	private void moveUp() {
		if(rigidBody.transform.position.y < -1.3f && !isDead)
		rigidBody.transform.position = new Vector2 (
			rigidBody.transform.position.x ,
			rigidBody.transform.position.y + (0.5f * Time.deltaTime)
		);
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Capsule") {
			Destroy (coll.gameObject);
			Debug.Log ("Capsule detected");
		}
		if (coll.gameObject.tag == "Database") {
			CapsuleStore.AddCapsule (1);
			//direction = getRandomDirection ();
			Debug.Log ("Added Capsule");
		}
	}
}
