using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CapsuleBalanceChanged : EventArgs {

	public CapsuleBalanceChanged(int oldBallance,int newBallance){
		this.OldBallance = oldBallance;
		this.NewBallance = newBallance;
	}

	public int NewBallance {
		get;
		private set;
	}

	public int OldBallance {
		get;
		private set;
	}
}
