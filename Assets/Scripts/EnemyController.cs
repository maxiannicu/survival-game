using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

public class EnemyController : AbstractCharacter {
	private GameObject _base;
	private bool fighting;
	private RegisteredTimer damageAction;
	private Animator animator;
	private GameObject _killingGameObject;


	public int DamageCaused = 1;
	public int FightInterval = 1;


	// Use this for initialization
	void Start () {
		fighting = false;
		animator = GetComponent<Animator>();
		_base = GameObject.FindGameObjectWithTag ("Database");
	}
	
	// Update is called once per frame
	public void Update () {
		base.Update();

		if(!fighting || PeriodController.CurrentPeriod == Period.Day)
			move (GetMovingDirection());
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (Helper.CanFire (coll.gameObject)) {
			fighting = true;
			animator.SetBool ("Fighting", true);
			damageAction = new RegisteredTimer (Shoot, FightInterval);
			StartTimer (damageAction);
		}
	}
		

	void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject == _killingGameObject) {
			StopFighting ();
		}
	}

	public void Shoot(){
		if (Helper.CanFire (_killingGameObject)) {
			var healthController = _killingGameObject.GetComponent<HealthController> ();
			healthController.Damage (DamageCaused);
		} else {
			_killingGameObject = null;
			StopFighting ();
		}
	}

	public int GetMovingDirection(){		
		var direction = this.transform.position.x - _base.transform.position.x;

		if (direction > 0) {
			return PeriodController.CurrentPeriod == Period.Day ? 1 : -1;
		} else {
			return PeriodController.CurrentPeriod == Period.Day ? -1 : 1;
		}
	}

	private void StopFighting(){
		fighting = false;
		animator.SetBool ("Fighting", false);
		UnregisterAction (damageAction);
	}

}
