using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCharacter : MonoBehaviour {

	protected bool isDead;
	public float Speed;
	public int Life = 100;
	public Rigidbody2D rigidBody;


	protected void move(float direction) {
		if (!IsDead ()) {
			changeDirection (direction);
			rigidBody.transform.position = new Vector2 (
				rigidBody.transform.position.x + (Speed * direction * Time.deltaTime),
				rigidBody.transform.position.y
			);
		}
	}

	private void changeDirection(float direction) {
		if (direction < 0) {
			rigidBody.transform.localScale = new Vector3 (-1f, 1f, 1f);
		} else if (direction > 0) {
			rigidBody.transform.localScale = new Vector3 (1f, 1f, 1f);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("DSAdas");
		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SendMessage("ApplyDamage", 10);

	}

	protected bool IsDead(){
		return isDead;
	}

	protected void SetStateIsDead(bool isDead) {
		this.isDead = isDead; 
	}

}
