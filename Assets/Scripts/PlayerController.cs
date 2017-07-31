using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : AbstractCharacter
{
    public AudioClip gotCoinClip;
	private GameObject _collidingCapsule;
	public TooltipRender TooltipRender;

	void Update () {
		DirectionUpdate ();

		if (_collidingCapsule != null) {
			if (Input.GetKey (KeyCode.DownArrow)) {
				Extract ();
			}
		}
	}

	void OnDestroy(){
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
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
        SoundManager.instance.PlaySingle(gotCoinClip);
	}

}
