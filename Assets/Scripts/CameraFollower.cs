using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
	public GameObject follower;
		
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (
			follower.transform.position.x,
			follower.transform.position.y,
			gameObject.transform.position.z
		);
	}
}
