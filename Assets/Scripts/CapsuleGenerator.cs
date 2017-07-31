using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGenerator : MonoBehaviour {
	private const float _scanInterval = Constants.Game.CapsuleSpawnInterval;
	private float _lastScanTime = _scanInterval;

	public Vector2 GenerationRange; // range of capsule generation
	public float GenerationPositionY = 0;
	public GameObject Capsule;
	public int MaxCapsuleAtOneTime = Constants.Game.MaxCapsules;
				
	// Update is called once per frame
	public void Update () {
		_lastScanTime += Time.deltaTime;
		if (_lastScanTime > _scanInterval) {
			if (GameObject.FindGameObjectsWithTag ("Capsule").Length < MaxCapsuleAtOneTime) {
				GenerateNewCapsule ();
			}
			_lastScanTime = 0;
		}
	}

	private void GenerateNewCapsule(){
		var newPosition = new Vector2 (MathUtils.RandomInRange(GenerationRange.x,GenerationRange.y), GenerationPositionY);
		var gameObject = Instantiate (Capsule, newPosition,Capsule.transform.rotation);
		gameObject.transform.parent = this.gameObject.transform;
	}
}
