using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

	private bool allowBuying = false;

	// Update is called once per frame
	void Update () {
		//Debug.Log(allowBuying);
		if (allowBuying) {
			if (Input.GetKeyDown(KeyCode.B)) {
				try {
					Debug.Log("Droid bought");
					CapsuleStore.Buy ();
				} catch (Exception e) {
					Debug.LogException (e, this);
				}
			}
		}
	}

	void OnTrigerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Farmer") {
			allowBuying = true;
			Debug.Log ("Farmer detected");
		}
	}
}
