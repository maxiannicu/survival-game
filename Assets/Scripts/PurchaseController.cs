using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PurchaseController : MonoBehaviour {
	private UpgradableComponent _upgradableComponent = null;

	public void Update(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (_upgradableComponent != null && _upgradableComponent.IsUpgradable) {
				try {
					_upgradableComponent.Upgrade ();
					Debug.Log ("Purchased");
				} catch (Exception ex) {
					Debug.Log ("Could not upgrade, cause : " + ex.Message);
				}
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D collision) {
		_upgradableComponent = collision.GetComponent<UpgradableComponent> ();

		if (_upgradableComponent != null) {
			Debug.Log ("Found upgradable component");
		}
	}

	public void OnTriggerExit2D(Collider2D collision) {
		_upgradableComponent = null;
	}
}
