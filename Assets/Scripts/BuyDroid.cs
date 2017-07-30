using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyDroid : MonoBehaviour {

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
			Debug.Log ("Farmer detected");
		}
	}

	private void BuyingDroid(){
		if (allowBuying) {
			if (Input.GetKeyDown(KeyCode.B)) {
				Debug.Log ("Try to buy");
				try {
					Debug.Log("Droid bought");
					CapsuleStore.Buy ();
				} catch (Exception e) {
					Debug.LogException (e, this);
				}
			}
		}
	}
}
