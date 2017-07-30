using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

public class EnemyController : AbstractCharacter {

	private PeriodController period;
	public GameObject database;
	public bool fighting;
	private RegisteredTimer damageAction;
	private Animator animator;


	// Use this for initialization
	void Start () {
		fighting = false;
		Speed = 0.3f;
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
		if (PeriodController.Instance.CurrentPeriod == Period.Day) {
			if (!fighting) {
				moveEnemy (-1);
			}
		} else {
			moveEnemy (1);
		}
	}

	private void moveEnemy(int direction) {
		if (gameObject.transform.position.x > database.transform.position.x) {
			move (direction);
		} else {
			move (-direction);
		}
	}


	void OnTriggerEnter2D(Collider2D coll) {
		HealthController healthController = coll.gameObject.GetComponent<HealthController> ();
		if (healthController != null) {
			fighting = true;
			Debug.Log ("Started fighting");
			animator.SetBool ("Fighting", true);
			damageAction = new RegisteredTimer (() => healthController.Damage (1), 1);
			StartTimer (damageAction);
		}
	}
		

	void OnTriggerExit2D() {
		fighting = false;
		Debug.Log ("Finished fighting");
		animator.SetBool ("Fighting", false);
		UnregisterAction (damageAction);
	}


}
