using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PeriodChangeEvent : EventArgs {
	public PeriodChangeEvent(Period period){
		CurrentPeriod = period;
	}

	public Period CurrentPeriod {
		get;
		private set;
	}
}
