using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PeriodChangeEvent : EventArgs {
	public PeriodChangeEvent(int cycle, Period period){
		CurrentPeriod = period;
	}

	public int Cycle {
		get;
		private set;
	}

	public Period CurrentPeriod {
		get;
		private set;
	}
}
