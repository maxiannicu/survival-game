using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {
	public int Health = 1;

	public virtual bool IsAlive {
		get {
			return Health > 0;
		}
	}

	public virtual void Damage(int damage){
		Health -= damage;
		if (Health <= 0) {
			Debug.Log ("Object destroyed");
			Destroy (this.gameObject);
		}
	}
}
