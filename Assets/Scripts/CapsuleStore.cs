using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CapsuleStore {
	#region Fields
	private static int _capsuleCount = 0;
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
		
		var oldBalance = _capsuleCount;
		_capsuleCount++;
	}
	#endregion
}
