using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CapsuleStore : MonoBehaviour {
	#region Fields
	private int _capsuleCount = 0;
	#endregion

	#region Events
	public event EventHandler<CapsuleBalanceChanged> CapsuleChangeEvent;
	#endregion

	#region Properties
	public int Capsules {
		get {
			return _capsuleCount;
		}
	}

	public int MaxCapsules {
		get {
			return 100;
		}
	}
	#endregion

	#region Methods
	public void AddCapsule(){
		var oldBalance = _capsuleCount;
		_capsuleCount++;
		if (CapsuleChangeEvent != null) {
			CapsuleChangeEvent (this, new CapsuleBalanceChanged (oldBalance, _capsuleCount));
		}
	}
	#endregion
}
