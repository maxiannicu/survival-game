using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CapsuleStore {
	
	#region Fields
	private static int _capsuleCount = Constants.Game.InitialCapsules;
	#endregion

	#region Properties
	public static int Capsules {
		get {
			return _capsuleCount;
		}
	}

	public static int MaxCapsules {
		get {
			return Constants.Game.MaxCapsules;
		}
	}
	#endregion

	#region Methods
	public static void AddCapsule(int capsules){
		_capsuleCount = Math.Min (_capsuleCount + capsules, Constants.Game.MaxCapsules);
	}


	public static bool HasCapsules(int count){
		return Capsules >= count;
	}

	public static void Buy(int price){
		if (!HasCapsules(price)) {
			throw new Exception ("Not enoght capsules");
		}

		_capsuleCount -= price;
	}

	#endregion
}
