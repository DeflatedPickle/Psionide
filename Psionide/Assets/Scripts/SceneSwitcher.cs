﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {
	public void LoadScene(string scene) {
		Util.IsPaused = false;
		SceneManager.LoadScene(scene);
	}

	public void Quit() {
		Application.Quit();
	}
}