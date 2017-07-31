using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradableHealthController : HealthController {
	private int _level = -1;
	private UpgradableComponent _upgradableComponent;

	public List<int> UpgradableHealth;

	public void Start(){
		_upgradableComponent = GetComponent<UpgradableComponent> ();
	}

	public void Update(){
		if (_level != _upgradableComponent.Level) {
			CopyUpgradeParams ();
		}
	}

	protected override void OnKilled(){
		_upgradableComponent.Reset ();
		CopyUpgradeParams ();
	}

	private void CopyUpgradeParams(){
		_level = _upgradableComponent.Level;
		Health = UpgradableHealth [Mathf.Max(0,Mathf.Min(_level,UpgradableHealth.Count - 1))]; 
	}
}
