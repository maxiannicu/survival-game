using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class EnemyController : AbstractCharacter {

	private PeriodController period;
	public GameObject database;
	private bool isFighting;

	// Use this for initialization
	void Start () {
		isFighting = false;
		Speed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (PeriodController.Instance.CurrentPeriod == Period.Day) {
			if(!isFighting)
				if (gameObject.transform.position.x > database.transform.position.x) {
					move (-1);
				} else {
					move (1);
				}

		} else {
			
		}
	}


	void OnTriggerStay2D(Collider2D coll) {
		HealthController healthController = coll.gameObject.GetComponent<HealthController> ();
		if (healthController != null) {
			isFighting = true;
			Debug.Log ("Started fighting");
			healthController.Damage (1); // harcoded
		}
	}


	void OnTriggerExit2D() {
		isFighting = false;
	}


}
