using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundController : MonoBehaviour {
	public float backgroundSize;
	public float paralaxSpeed;

	private Transform cameraTransforms;
	private Transform[] layers;
	private float viewZone = 1f;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;

	private void Start(){
		cameraTransforms = Camera.main.transform;
		lastCameraX = cameraTransforms.position.x;
		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			layers [i] = transform.GetChild(i);
		}

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}

	private void Update() {
		float deltaX = cameraTransforms.position.x - lastCameraX;
		transform.position  += Vector3.right * (deltaX * paralaxSpeed);
		lastCameraX = cameraTransforms.position.x;

		if (cameraTransforms.position.x < (layers[leftIndex].transform.position.x + viewZone))
			ScrollLeft();
		if (cameraTransforms.position.x > (layers[rightIndex].transform.position.x - viewZone))
			ScrollRight ();
	}


	private void ScrollLeft() {
		layers[rightIndex].position = Vector3.right * (layers [leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex--;
		Debug.Log ("Left index: "+rightIndex);
		if (rightIndex < 0) {
			rightIndex = layers.Length - 1;
		}
	}

	private void ScrollRight() {
		layers[leftIndex].position = Vector3.right * (layers [rightIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex++;
		Debug.Log ("Right index: "+rightIndex);
		if (leftIndex == layers.Length) {
			leftIndex = 0;
		}
	}
}
