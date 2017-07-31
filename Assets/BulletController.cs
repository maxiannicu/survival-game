using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x > 10 || gameObject.transform.position.x < -10) {
			Destroy (this.gameObject);
		}
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			HealthController healthController = coll.gameObject.GetComponent<HealthController> ();
			healthController.Damage (1);
			Destroy (this.gameObject);
		}
	}
}
