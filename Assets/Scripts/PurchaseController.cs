﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PurchaseController : MonoBehaviour {
	private UpgradableComponent _upgradableComponent = null;
	public CapsulePriceRender CapsulePriceRender;

	public void Update(){
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (_upgradableComponent != null && _upgradableComponent.IsUpgradable) {
				try {
					_upgradableComponent.Upgrade ();
					ShowPrice ();
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
			ShowPrice ();
		}
	}

	public void OnTriggerExit2D(Collider2D collision) {
		if (_upgradableComponent != null) {
			Debug.Log ("Exiting area of upgradable component");
		}
		_upgradableComponent = null;
		HidePrice ();
	}

	private void ShowPrice(){
		if (_upgradableComponent.IsUpgradable) {
			CapsulePriceRender.Activate (_upgradableComponent.UpgradePrice);
		} else {
			HidePrice ();
		}
	}

	private void HidePrice(){
		CapsulePriceRender.DeActivate ();
	}
}
