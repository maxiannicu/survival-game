using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBar : MonoBehaviour {
	public Texture2D Background;
	public Texture2D Fill;
	public Vector2 Position = new Vector2(40,40);
	public Vector2 Size = new Vector2(400,50);

	public int Progress = 5;
	public int Max = 10;

	void OnGUI() {
		GUI.BeginGroup(new Rect(Position.x, Position.y, Size.x, Size.y));
		GUI.DrawTexture(new Rect(0,0, Size.x, Size.y),Background);
	
		var width = Size.x / Max;
		var height = Size.y;
		for (int i = 0; i < Progress; i++) {
			var rect = new Rect (i * width, 0, width, height);
			GUI.DrawTexture(rect ,Fill);
		}

		GUI.EndGroup();
	}
}
