using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PurchaseController : MonoBehaviour {
	private System.Diagnostics.Stopwatch _stopWatch = new System.Diagnostics.Stopwatch();
	private int _currentState = 0;
	private UpgradableComponent _upgradableComponent = null;
	public CapsulePriceRender CapsulePriceRender;
	public TooltipRender TooltipRender;
    public AudioClip upgrade;

	public void Update(){
		if (_upgradableComponent != null && _upgradableComponent.IsUpgradable && CapsuleStore.HasCapsules(_currentState+1)) {
			if(Input.GetKeyUp(KeyCode.DownArrow)){
				if (_currentState < _upgradableComponent.UpgradePrice) {
					_currentState++;
					ResetTimer ();

				} 

				if (_currentState == _upgradableComponent.UpgradePrice) {
					try {
						_upgradableComponent.Upgrade ();
                        SoundManager.instance.PlaySingle(upgrade);
						_currentState = 0;
						ResetTimer();
						Debug.Log ("Purchased");
					} catch (Exception ex) {
						Debug.Log ("Could not upgrade, cause : " + ex.Message);
					}
				}
			}

		}

		if (_stopWatch.ElapsedMilliseconds >= Constants.Game.MaxBuyDelayBetweenButtons) {
			_currentState = 0;
		}

		if (_upgradableComponent != null) {
			ShowPrice ();
		}
	}

	public void OnTriggerEnter2D(Collider2D collision) {
		if (_upgradableComponent != null) {
			return;
		}
		_upgradableComponent = collision.GetComponent<UpgradableComponent> ();

		if (_upgradableComponent != null) {			
			Debug.Log ("Found upgradable component");
			ShowPrice ();
		}
	}

	public void OnTriggerExit2D(Collider2D collision) {
		var component = collision.GetComponent<UpgradableComponent> ();
		if (component != _upgradableComponent) {
			return;
		}
		if (_upgradableComponent != null) {
			Debug.Log ("Exiting area of upgradable component");
		}
		_upgradableComponent = null;
		_currentState = 0;
		HidePrice ();
	}

	private void ShowPrice(){
		if (_upgradableComponent != null && _upgradableComponent.IsUpgradable) {
			CapsulePriceRender.Show (_currentState, _upgradableComponent.UpgradePrice);
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

	private void ResetTimer(){
		_stopWatch.Reset ();
		_stopWatch.Start ();
	}
}
