using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

public class EnemyController : AbstractCharacter {
	public GameObject _base;
	public bool fighting;
	private RegisteredTimer damageAction;
	private Animator animator;


	// Use this for initialization
	void Start () {
		fighting = false;
		animator = GetComponent<Animator>();
		_base = GameObject.FindGameObjectWithTag ("Database");
	}
	
	// Update is called once per frame
	public void Update () {
		base.Update();

		move (GetMovingDirection());
	}

	void OnTriggerEnter2D(Collider2D coll) {
		HealthController healthController = coll.gameObject.GetComponent<HealthController> ();
		if (healthController != null) {
			fighting = true;
			animator.SetBool ("Fighting", true);
			damageAction = new RegisteredTimer (() => healthController.Damage (1), 1);
			StartTimer (damageAction);
		}
	}
		

	void OnTriggerExit2D() {
		fighting = false;
		animator.SetBool ("Fighting", false);
		UnregisterAction (damageAction);
	}

	public int GetMovingDirection(){		
		var direction = this.transform.position.x - _base.transform.position.x;

		if (direction > 0) {
			return PeriodController.CurrentPeriod == Period.Day ? 1 : -1;
		} else {
			return PeriodController.CurrentPeriod == Period.Day ? -1 : 1;
		}
	}

}
