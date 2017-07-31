using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseController : MonoBehaviour {

	void OnDesotroy(){
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}
