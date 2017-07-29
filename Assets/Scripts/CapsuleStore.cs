using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CapsuleStore {
	
	#region Fields
	private static int _capsuleCount = 0;
	private const int _droidPrice = 1;
	#endregion

	#region Properties
	public static int Capsules {
		get {
			return _capsuleCount;
		}
	}

	public static int MaxCapsules {
		get {
			return 10;
		}
	}
	#endregion

	#region Methods
	public static void AddCapsule(){
		if (Capsules >= MaxCapsules)
			return;
		
		_capsuleCount++;
	}

	public static bool CanBuyDroid(){
		return Capsules > _droidPrice;
	}

	public static void BuyDroid(){
		if (!CanBuyDroid ()) {
			throw new Exception ("Not enoght capsules");
		}

		_capsuleCount -= _droidPrice;
	}

	#endregion
}
