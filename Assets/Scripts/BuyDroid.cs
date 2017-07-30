using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyDroid : DroidCharacter {

	private bool allowBuying;
	// Use this for initialization
	void Start () {

	}

	void Update() {
		BuyingDroid ();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Capsule") {
			CapsuleStore.AddCapsule ();
			Destroy (coll.gameObject);
			Debug.Log ("Capsule detected");
		}

		if (coll.gameObject.tag == "Farmer" ) {
			allowBuying = true;
			SetStateIsDead (false);
			Debug.Log ("Farmer detected");
			Debug.Log ("Farmer is dead: " + IsDead());
		}
	}

	private void BuyingDroid(){
		if (!IsDead ()) {
			if (allowBuying) {
				if (Input.GetKeyDown (KeyCode.B)) {
					try {
						Debug.Log ("Droid bought");
						Debug.Log ("Droid is working");
						CapsuleStore.BuyDroid ();
						SetStateIsDead(false);

					} catch (Exception e) {
						Debug.LogException (e, this);
					}
				}
			}
		}
	}
}
