using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CycleDrawer : MonoBehaviour {
	private Text _text;

	// Use this for initialization
	void Start () {
		_text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		_text.text = PeriodController.Cycle+"";
	}
}
