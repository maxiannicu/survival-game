using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PurchaseController : MonoBehaviour {
	private System.Diagnostics.Stopwatch _stopWatch = new System.Diagnostics.Stopwatch();
	private UpgradableComponent _upgradableComponent = null;
	public CapsulePriceRender CapsulePriceRender;
	public TooltipRender TooltipRender;

	public void Update(){
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			_stopWatch.Start ();
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			if (_upgradableComponent != null && _upgradableComponent.IsUpgradable) {
				if (_stopWatch.ElapsedMilliseconds >= _upgradableComponent.UpgradePrice * Constants.Game.MilliSecondsToBuyOneCapsule) {
					try {
						_upgradableComponent.Upgrade ();
						_stopWatch.Stop ();
						Debug.Log ("Purchased");
					} catch (Exception ex) {
						Debug.Log ("Could not upgrade, cause : " + ex.Message);
					}
				}
				ShowPrice ();
			}
		}

		if (Input.GetKeyUp (KeyCode.DownArrow)) {
			_stopWatch.Stop ();
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
			var progress = (int)Math.Truncate(1.0f * _stopWatch.ElapsedMilliseconds / Constants.Game.MilliSecondsToBuyOneCapsule);
			CapsulePriceRender.Show (progress, _upgradableComponent.UpgradePrice);
			switch (_upgradableComponent.UpgradeType) {
			case UpgradableComponent.Type.Activable:
				TooltipRender.ShowActivateTooltip ();
				break;
			case UpgradableComponent.Type.Upgradable:
				TooltipRender.ShowUpgradeTooltip ();
				break;
			}
		} else {
			HidePrice ();
		}
	}

	private void HidePrice(){
		CapsulePriceRender.Hide ();
		TooltipRender.HideTooltip ();
	}
}
