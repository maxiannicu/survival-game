using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuyDroid : MonoBehaviour {

	private bool allowBuying = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (allowBuying) {
			if (Input.GetKeyDown(KeyCode.B)) {
				try {
					Debug.Log("Droid bought");
					CapsuleStore.BuyDroid ();
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
