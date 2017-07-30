using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AbstractCharacter {

	// Use this for initialization
	void Start () {
		Speed = 9f;
	}


	void Update () {
		DirectionUpdate ();
	}

	private void DirectionUpdate(){
		var direction = Input.GetAxis ("Horizontal");
		move (direction);
	}
}
