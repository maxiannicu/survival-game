using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradableComponent : MonoBehaviour {
	private int _currentLevel = 0;
	public List<int> UpgradePrices;

	public int Level {
		get {
			return _currentLevel;
		}
	}

	public bool IsBought {
		get {
			return  _currentLevel > 0;
		}
	}

	public bool IsUpgradable {
		get {
			return  _currentLevel < UpgradePrices.Count - 1;
		}
	}

	public int UpgradePrice {
		get {
			if (!IsUpgradable) {
				throw new Exception ("This element could not be upgraded anymore");
			}
			return UpgradePrices [_currentLevel];
		}
	}

	public void Upgarde(){
		if (!IsUpgradable) {
			throw new Exception ("Could not upgrade. Maximal level reached.");
		}

		if (!CapsuleStore.HasCapsules(UpgradePrice)) {
			throw new Exception ("Not enought money");
		}

		CapsuleStore.Buy (UpgradePrice);
		_currentLevel++;
	}
}
