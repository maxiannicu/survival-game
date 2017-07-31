using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper {
	public static bool CanFire(GameObject gameObject){
		if (gameObject == null)
			return false;
		
		var healthController = gameObject.GetComponent<HealthController> ();
		var upgradableComponent = gameObject.GetComponent<UpgradableComponent> ();


		var result = healthController != null && healthController.IsAlive;

		if (upgradableComponent != null) {
			result = result && upgradableComponent.IsPurchased;
		}

		return result;
	}
}
