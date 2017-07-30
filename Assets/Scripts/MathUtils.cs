using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtils {
	private static readonly System.Random _random = new System.Random();

	public static float RandomInRange(float a,float b){
		return a + (float)_random.NextDouble() * (b - a); 
	}
}
