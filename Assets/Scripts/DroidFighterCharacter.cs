using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidFighterCharacter : AbstractCharacter {
	private UpgradableComponent _upgradableComponent;
	private int direction;
	public GameObject Bullet;

	// Use this for initialization
	void Start () {
		_upgradableComponent = GetComponent<UpgradableComponent> ();
		SetIdle (true);
		direction = 1;

	}
	
	// Update is called once per frame
	public new void Update () {
		shoot ();
		moveUp ();
		SetIdle (!_upgradableComponent.IsPurchased);
		if (gameObject.transform.position.x > 0) {
			move (-1);
		} else {
			move (1);
		}

	}

	private void moveUp() {
		if(rigidBody.transform.position.y < -1.3f && !isDead)
		rigidBody.transform.position = new Vector2 (
			rigidBody.transform.position.x ,
			rigidBody.transform.position.y + (0.5f * Time.deltaTime)
		);
	}




	private void shoot() {
		if (!IsDead ()) {
			var bullet = (GameObject)Instantiate (Bullet,
				             gameObject.transform.position,
				             gameObject.transform.rotation);	

			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (direction * 6f, 0); 
		}

	}
}
