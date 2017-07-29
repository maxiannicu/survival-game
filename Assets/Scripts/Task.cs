using System;
using UnityEngine;


namespace AssemblyCSharp {
	public class Task {	
		private GameObject gameObject;

		public GameObject GameObject {
			get{
				return gameObject;
			}	

			set{
				gameObject = value;
			}
		}
	}
}

