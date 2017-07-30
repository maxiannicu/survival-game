using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipRender : MonoBehaviour {
	private Image _tooltipImage;
	public Sprite PressToActivate;
	public Sprite PressToUpgrade;
	public Sprite PressToExtract;

	public void Start(){
		_tooltipImage = GetComponent<Image> ();
		HideTooltip ();
	}

	public void ShowActivateTooltip(){
		ShowSprite (PressToActivate);
	}

	public void ShowUpgradeTooltip(){
		ShowSprite (PressToUpgrade);
	}

	public void ShowExtractTooltip(){
		ShowSprite (PressToExtract);
	}

	public void HideTooltip(){
		_tooltipImage.enabled = false;
	}

	private void ShowSprite(Sprite sprite){
		_tooltipImage.enabled = true;
		_tooltipImage.sprite = sprite;
		_tooltipImage.SetNativeSize ();
	}
}
