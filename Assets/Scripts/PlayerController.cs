using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AbstractCharacter {
	private GameObject _collidingCapsule;
	public TooltipRender TooltipRender;

	void Update () {
		DirectionUpdate ();

		if (_collidingCapsule != null) {
			if (Input.GetKeyUp (KeyCode.DownArrow)) {
				Extract ();
			}
		}
	}

	private void DirectionUpdate(){
		var direction = Input.GetAxis ("Horizontal");
		move (direction);
	}


	public void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Capsule") {
			_collidingCapsule = coll.gameObject;
			TooltipRender.ShowExtractTooltip ();
		}
	}

	public void OnTriggerExit2D(Collider2D coll) {
		if (coll.gameObject.tag == "Capsule") {
			_collidingCapsule = null;
			TooltipRender.HideTooltip ();
		}
	}

	public void Extract(){
		Destroy (_collidingCapsule);
		CapsuleStore.AddCapsule (1);
		Debug.Log ("Extracted");
	}
}
