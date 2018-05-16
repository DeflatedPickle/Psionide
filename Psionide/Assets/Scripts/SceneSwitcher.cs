using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {
	public void LoadScene(string scene) {
		Util.IsDead = false;
		SceneManager.LoadScene(scene);
	}

	public void Quit() {
		Application.Quit();
	}
}