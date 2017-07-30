﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {
	public int Health = 1;

	public void Damage(int damage){
		Health -= damage;
		Debug.Log ("Damage!!!");
		if (Health <= 0) {
			Destroy (this.gameObject);
		}
	}
}
