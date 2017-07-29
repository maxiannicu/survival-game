using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleBar : MonoBehaviour {
	private Image _image;

	public void Start(){
		_image = gameObject.GetComponent<Image> ();
	}

	public void Update() {
		_image.fillAmount = CapsuleStore.Capsules * 1.0f / CapsuleStore.MaxCapsules;
	}
}
