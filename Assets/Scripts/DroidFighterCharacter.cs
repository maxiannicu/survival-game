using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidFighterCharacter : AbstractCharacter {
	private UpgradableComponent _upgradableComponent;
	private int direction;
	public GameObject Bullet;
	private GameObject _database;
	public int state = 0; // 0 - idle, 1 - movingUp, 2 - day mode, 3 - night mode
	private System.Random random = new System.Random();
	private RegisteredTimer _action;


	// Use this for initialization
	void Start () {
		_upgradableComponent = GetComponent<UpgradableComponent> ();
		_database = GameObject.FindGameObjectWithTag ("Database");
		SetIdle (true);
		direction = GetRandomDirection ();
		state = 0;

	}
	
	// Update is called once per frame

	public new void Update () {
		SetIdle (!_upgradableComponent.IsPurchased);

		switch (state) {
		case 0:
			checkIfIdle ();// In this state droid is idle
			break;
		case 1:
			moveUp (); // Rising from the ground
			break;
		case 2:
			wanderAround (); // Day time - just random walking
			break;
		case 3:
			goToTheWall ();
			break;
		case 4:
			killEnemies ();
			break;

		}
			
	}

	private void moveUp() {
		if (rigidBody.transform.position.y < -1.3f && state == 1) {
			
			rigidBody.transform.position = new Vector2 (
				rigidBody.transform.position.x,
				rigidBody.transform.position.y + (0.5f * Time.deltaTime)
			);
		} else {
			state = 2;
		}

		if(PeriodController.CurrentPeriod.Equals(Period.Night)) {
			state = 3;
		}
	}



	private void shoot() {
		if (!IsDead ()) {
			var bullet = (GameObject)Instantiate (Bullet,
				             gameObject.transform.position,
				             gameObject.transform.rotation);	

			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (direction * 6f, 0); 
		}
	}


	private void wanderAround() {
		move (direction);
		if (this.gameObject.transform.position.x < -4) {
			direction = 1;
		}

		if (this.gameObject.transform.position.x > 10) {
			direction = -1;
		}

		if(PeriodController.CurrentPeriod.Equals(Period.Night)) {
			state = 3;
		}
	}

	private void checkIfIdle() {
		if (!IsDead ()) {
			state = 1;
		}
	}
		

	private int GetRandomDirection() {
		return random.NextDouble () > 0.5 ? -1 : 1;
	}

	private void goToTheWall() {
		if (gameObject.transform.position.x + random.NextDouble() < -3.6 || gameObject.transform.position.x + random.NextDouble() > 10) {
			_action = new RegisteredTimer (() => shoot(), 1);
			StartTimer (_action);
			state = 4;
		}

		if (Mathf.Abs (gameObject.transform.position.x - 10) > Mathf.Abs (-4 - gameObject.transform.position.x)) {
			move (-1);
		} else {
			move(1);
		}

		if(PeriodController.CurrentPeriod.Equals(Period.Day)) {
			state = 1;
		}
			
	}

	private void killEnemies() {
		shoot ();

		if(PeriodController.CurrentPeriod.Equals(Period.Day)) {
			state = 1;
			UnregisterAction (_action);
		}
	}



}
