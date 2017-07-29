using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGenerator : MonoBehaviour {
	private System.Random _random = new System.Random();
	private const float _scanInterval = 1;
	private float _lastScanTime = _scanInterval;

	public Vector2 GenerationRange; // range of capsule generation
	public float GenerationPositionY = 0;
	public GameObject Capsule;
	public GameObject GenerationLayer;
	public int MaxCapsuleAtOneTime = 10;

			
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
		var newPosition = new Vector2 ((float)_random.NextDouble () * (GenerationRange.y - GenerationRange.x) + GenerationRange.x, GenerationPositionY);
		var gameObject = Instantiate (Capsule, newPosition,Capsule.transform.rotation);
		gameObject.transform.parent = GenerationLayer.transform;
	}
}
