using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
	public Rigidbody2D body;
	public float velocity = 0.5f;
	public float jumpForce = 10f;

	// Use this for initialization
	void Start () {
		
	}


	void Update () {
		DirectionUpdate ();
	}

	private void DirectionUpdate(){
		var direction = Input.GetAxis ("Horizontal");

		body.transform.position = new Vector2 (
			body.transform.position.x + (velocity * direction * Time.deltaTime),
			body.transform.position.y
		);
	}
}
