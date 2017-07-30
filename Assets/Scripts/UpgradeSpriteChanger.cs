using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpriteChanger : MonoBehaviour {
	private int _currentDisplayed = -1;
	private UpgradableComponent _upgradableComponent;
	private SpriteRenderer _spriteRenderer;

	public List<Sprite> UpgradeSprites;

	// Use this for initialization
	void Start () {
		_upgradableComponent = GetComponent<UpgradableComponent> ();
		_spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (_spriteRenderer != null && _upgradableComponent != null) {
			if (_currentDisplayed != _upgradableComponent.Level) {
				_currentDisplayed = _upgradableComponent.Level;

				if (_currentDisplayed >= UpgradeSprites.Count) {
					Debug.Log ("Could not render new level sprite. It has no asset.");
				} else {
					_spriteRenderer.sprite = UpgradeSprites [_currentDisplayed];
				}
			}
		}
	}
}
