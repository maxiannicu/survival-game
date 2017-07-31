using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UpgradableComponent : MonoBehaviour {
	private int _currentLevel = -1;
	public List<int> UpgradePrices;
	public Type UpgradeType = Type.Upgradable;

	public int Level {
		get {
			return _currentLevel;
		}
	}

	public bool IsPurchased {
		get {
			return  _currentLevel > -1;
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
			return UpgradePrices [_currentLevel+1];
		}
	}

	public void Upgrade(){
		if (!IsUpgradable) {
			throw new Exception ("Could not upgrade. Maximal level reached.");
		}

		if (!CapsuleStore.HasCapsules(UpgradePrice)) {
			throw new Exception ("Not enought money");
		}

		CapsuleStore.Buy (UpgradePrice);
		_currentLevel++;
	}

	public void Reset(){
		_currentLevel = -1;
	}

	public enum Type {
		Upgradable,
		Activable
	}
}
