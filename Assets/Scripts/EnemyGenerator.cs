using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
	public List<Vector2> GenerationPoints;
	public float GenerationY;
	public List<int> GenerationNumber;
	public GameObject Enemy;

	// Use this for initialization
	void Start () {
		PeriodController.PeriodChangeEvent += OnPeriodChange;	
	}

	void OnDestroy(){
		PeriodController.PeriodChangeEvent -= OnPeriodChange;
	}

	public void OnPeriodChange(object sender, PeriodChangeEvent periodChangeEvent){
		if (periodChangeEvent.CurrentPeriod == Period.Night) {
			var number = GenerationNumber [Mathf.Min (GenerationNumber.Count - 1, periodChangeEvent.Cycle)];
			for (int i = 0; i < number; i++) {
				for (int e = 0; e < GenerationPoints.Count; e++) {
					var range = GenerationPoints [e];
					var x = MathUtils.RandomInRange (range.x, range.y);
					var gameObject = Instantiate(Enemy,new Vector3(
						x,
						GenerationY,
						0
					),Enemy.transform.rotation);
					gameObject.transform.parent = this.gameObject.transform;
				}
			}
		}
	}
}
