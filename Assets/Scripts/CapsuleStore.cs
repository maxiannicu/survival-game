using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CapsuleStore : MonoBehaviour {
	#region Fields
	private int _capsuleCount = 0;
	#endregion

	#region Properties
	public int Capsules {
		get {
			return _capsuleCount;
		}
	}

	public int MaxCapsules {
		get {
			return 10;
		}
	}
	#endregion

	#region Methods
	public void AddCapsule(){
		if (Capsules >= MaxCapsules)
			return;
		
		var oldBalance = _capsuleCount;
		_capsuleCount++;
	}
	#endregion
}
