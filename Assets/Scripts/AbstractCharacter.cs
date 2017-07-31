using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCharacter : BaseGameObject {
	protected bool isDead;
	public float Speed;
	public Rigidbody2D rigidBody;

	protected void move(float direction) {
		if (!IsDead ()) {
			var oldX = rigidBody.transform.position.x;
			var newX = oldX + (Speed * direction * Time.deltaTime);

			if (newX < oldX && newX < Constants.Limits.LeftSide) {
				return;
			}

			if (newX > oldX && newX > Constants.Limits.RightSide) {
				return;
			}

			changeDirection (direction);
			rigidBody.transform.position = new Vector2 (
				newX,
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
		if (coll.gameObject.tag == "Enemy")
			coll.gameObject.SendMessage("ApplyDamage", 10);
	}

	protected bool IsDead(){
		return isDead;
	}

	protected void SetIdle(bool isDead) {
		this.isDead = isDead; 
	}
}
