using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroidFighterCharacter : AbstractCharacter {
	private UpgradableComponent _upgradableComponent;
	private int direction;

	public float KillDistance = 0.5f;
	public GameObject Bullet;
	private GameObject _database;
	public int state = 0; // 0 - idle, 1 - movingUp, 2 - day mode, 3 - night mode
	public float KillFrequencySeconds = 1.0f;
	private System.Random random = new System.Random();
	private RegisteredTimer _action;
	private float _lastKill = 0;


	// Use this for initialization
	void Start () {
		_upgradableComponent = GetComponent<UpgradableComponent> ();
		_database = GameObject.FindGameObjectWithTag ("Database");
		SetIdle (true);
		direction = GetRandomDirection ();
		state = 0;
		_lastKill = KillFrequencySeconds*2;
	}
	
	// Update is called once per frame

	public new void Update () {
		_lastKill += Time.deltaTime;
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
			killEnemies ();
			break;

		}
			
	}

	private void moveUp() {
		if (rigidBody.transform.position.y < -1.3f && state == 1) {
			
			rigidBody.transform.position = new Vector2 (
				rigidBody.transform.position.x,
				rigidBody.transform.position.y + (0.1f * Time.deltaTime)
			);
		} else {
			state = 2;
		}

		if(PeriodController.CurrentPeriod.Equals(Period.Night)) {
			state = 3;
		}
	}



	private void shoot() {
			var bullet = (GameObject)Instantiate (Bullet,
				             gameObject.transform.position,
				             gameObject.transform.rotation);	

			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (direction * 4f, 0); 	
	}


	private void wanderAround() {
		move (direction);
		if (this.gameObject.transform.position.x < -4) {
			direction = 1;
		}

		if (this.gameObject.transform.position.x > 11) {
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

	private void killEnemies() {
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag ("Enemy");
		float minDistance = int.MaxValue;
		float position = 0f;


		foreach (GameObject obj in gameObjects) {
			if (Mathf.Abs (obj.transform.position.x - this.gameObject.transform.position.x) < minDistance) {
				var distance = Mathf.Abs (obj.transform.position.x - this.gameObject.transform.position.x);

				if (distance < minDistance) {
					minDistance = distance;
					position = obj.transform.position.x;
				}
			}
		}


		if (position > this.gameObject.transform.position.x) {
			direction = 1;
			move (direction);
		} else {
			direction = -1;
			move (direction);
		}

		if (Mathf.Abs (position - this.gameObject.transform.position.x)  < KillDistance) {
			if (_lastKill >= KillFrequencySeconds) {
				shoot ();
				_lastKill = 0;
			}
		} 

		if(PeriodController.CurrentPeriod.Equals(Period.Day)) {
			state = 1;
		}
	}
}
