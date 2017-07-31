﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

public class EnemyController : AbstractCharacter {
	public GameObject _base;
	private PeriodController period;
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
		if (PeriodController.CurrentPeriod == Period.Night) {
			if (!fighting) {
				moveEnemy (-1);
			}
		} else {
			moveEnemy (1);
		}
	}

	private void moveEnemy(int direction) {
		if (gameObject.transform.position.x > _base.transform.position.x) {
			move (direction);
		} else {
			move (-direction);
		}
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


}
