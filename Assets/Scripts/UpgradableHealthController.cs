using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradableHealthController : HealthController {
	private int _health;
	private int _level = -1;
	private UpgradableComponent _upgradableComponent;

	public List<int> UpgradableHealth;

	public void Start(){
		_upgradableComponent = GetComponent<UpgradableComponent> ();
	}

	public void Update(){
		if (_level != _upgradableComponent.Level) {
			_level = _upgradableComponent.Level;
			_health = UpgradableHealth [Mathf.Min(_level,UpgradableHealth.Count - 1)]; 
		}
	}

	public new void Damage(int damage){
		if (!_upgradableComponent.IsPurchased) {
			return;
		}
		Debug.Log ("UpgradableHealthController. Damage : " + damage + " , Health " + _health);
		_health -= damage;
		if (_health <= 0) {
			Destroy (this.gameObject);
		}
	}
}
