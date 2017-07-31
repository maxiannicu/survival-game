using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAddOn : MonoBehaviour {

	public Texture background;

	void OnGUI(){
		GUI.DrawTexture (new Rect (0, 0, 5f, 5f), background);
	}
}
