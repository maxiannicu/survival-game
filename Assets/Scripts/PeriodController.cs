using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PeriodController : MonoBehaviour {
	#region Fields
	private float _ellapsedTime;
	public static int PeriodTime = Constants.Game.PeriodTime;
	#endregion

	#region Events
	public static event EventHandler<PeriodChangeEvent> PeriodChangeEvent;
	#endregion

	#region Properties
	public static Period CurrentPeriod {
		get;
		private set;
	}

	public static int Cycle {
		get;
		private set;
	}
	#endregion

	#region Methods

	public void Start(){
		CurrentPeriod = Period.Day;
		Cycle = 0;
	}

	public void Update(){
		_ellapsedTime += Time.deltaTime;

		if (_ellapsedTime >= PeriodTime) {
			CurrentPeriod = (CurrentPeriod == Period.Day) ? Period.Night : Period.Day;

			if (CurrentPeriod == Period.Day) {
				Cycle++;
			}
			_ellapsedTime = 0;

			RaiseEvent ();
		}
	}

	private void RaiseEvent(){
		if (PeriodChangeEvent != null) {
			PeriodChangeEvent (this, new PeriodChangeEvent (Cycle,CurrentPeriod));
		}
	}
	#endregion
}
