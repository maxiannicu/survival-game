using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectGenerator : MonoBehaviour {
	private float _lastScanTime = 0;

	public Vector2 GenerationRange;
	public float GenerationPositionY = 0;
	public GameObject ClonedGameObject;
	public float SpawnInterval = 10;
	public int InitialSpawnCount = 0;

	public void Start(){
		for (int i = 0; i < InitialSpawnCount; i++) {
			GenerateNewObject ();
		}
	}

	public void Update () {
		_lastScanTime += Time.deltaTime;
		if (_lastScanTime > SpawnInterval) {
			GenerateNewObject ();
			_lastScanTime = 0;
		}
	}

	private void GenerateNewObject(){
		var newPosition = new Vector2 (MathUtils.RandomInRange(GenerationRange.x,GenerationRange.y), GenerationPositionY);
		var gameObject = Instantiate (ClonedGameObject, newPosition,ClonedGameObject.transform.rotation);
		gameObject.transform.parent = this.gameObject.transform;
	}
}
