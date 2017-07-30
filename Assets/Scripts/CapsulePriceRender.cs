using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePriceRender : MonoBehaviour {
	private int _count = 0;
	public Texture Capsule;
	public float OffsetBetweelCapsules;
	public float Y;
	public float XCenter;

	public void Start(){
		DeActivate ();
	}

	public void Activate(int count){
		this._count = count;
		enabled = true;
	}

	public void DeActivate(){
		this._count = 0;
		enabled = false;
	}

	public void OnGUI() 
	{
		if(this._count > 0){
			var occupedWidth = this._count * Capsule.width + ((this._count - 1) * OffsetBetweelCapsules);
			var startingX = XCenter - occupedWidth/2;
			for (int i = 0; i < this._count; i++) {
				GUI.DrawTexture (new Rect(startingX,Y, Capsule.width, Capsule.height), Capsule);
				startingX += Capsule.width;

				if (i < this._count - 1) {
					startingX += OffsetBetweelCapsules;
				}
			}

		}
	}
}
