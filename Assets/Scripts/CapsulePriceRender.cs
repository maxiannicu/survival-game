using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsulePriceRender : MonoBehaviour {
	private int _active = 0;
	private int _total = 0;

	public Texture CapsuleEmpty;
	public Texture CapsuleFill;
	public float OffsetBetweelCapsules;
	public float Y;
	public float XCenter;

	public void Start(){
		Hide ();
	}

	public void Show(int active,int total){
		this._active = active;
		this._total = total;
		enabled = true;
	}

	public void Hide(){
		this._active = 0;
		enabled = false;
	}

	public void OnGUI() 
	{
		if(this._total > 0){
			var occupedWidth = this._total * CapsuleEmpty.width + ((this._total - 1) * OffsetBetweelCapsules);
			var startingX = XCenter - occupedWidth/2;

			for (int i = 0; i < this._total; i++) {
				var texture = i < this._active ? CapsuleFill : CapsuleEmpty;
				GUI.DrawTexture (new Rect(startingX,Y, texture.width, texture.height), texture);
				startingX += texture.width;

				if (i < this._total - 1) {
					startingX += OffsetBetweelCapsules;
				}
			}

		}
	}

}
