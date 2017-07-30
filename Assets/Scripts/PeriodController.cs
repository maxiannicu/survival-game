using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PeriodController : MonoBehaviour {
	#region Fields
	private float _ellapsedTime;
	public int PeriodTime = Constants.Game.PeriodTime;
	public static PeriodController Instance;
	#endregion

	#region Events
	public event EventHandler<PeriodChangeEvent> PeriodChangeEvent;
	#endregion

	#region Properties
	public Period CurrentPeriod {
		get;
		private set;
	}
	#endregion

	#region Methods

	public void Start(){
		CurrentPeriod = Period.Day;
		Instance = this;
	}

	public void Update(){
		_ellapsedTime += Time.deltaTime;

		if (_ellapsedTime >= PeriodTime) {
			CurrentPeriod = (CurrentPeriod == Period.Day) ? Period.Night : Period.Day;
			_ellapsedTime = 0;

			if (PeriodChangeEvent != null) {
				PeriodChangeEvent (this, new PeriodChangeEvent (CurrentPeriod));
			}
		}
	}
	#endregion
}
