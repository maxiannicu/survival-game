using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;
using System;

public class EnemyController : AbstractCharacter {

	private PeriodController period;
	public GameObject database;
	private bool isFighting;
	private RegisteredTimer damageAction;

	// Use this for initialization
	void Start () {
		isFighting = false;
		Speed = 1f;
	}
	
	// Update is called once per frame
	public void Update () {
		base.Update();
		if (PeriodController.CurrentPeriod == Period.Night) {
			if (!isFighting) {
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
			isFighting = true;
			Debug.Log ("Started fighting");
			damageAction = new RegisteredTimer (() => healthController.Damage (1), 1);
			StartTimer (damageAction);
		}
	}
		

	void OnTriggerExit2D() {
		isFighting = false;
		Debug.Log ("Finished fighting");
		UnregisterAction (damageAction);
	}


}
