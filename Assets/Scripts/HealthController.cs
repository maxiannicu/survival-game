using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {
	public int Health = 1;

	public bool IsAlive {
		get {
			return Health > 0;
		}
	}

	public void Damage(int damage){
		Health -= damage;
		if (Health <= 0) {
			Destroy (this.gameObject);
		}
	}
}
