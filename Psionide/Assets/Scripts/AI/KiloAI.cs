using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiloAI : MonoBehaviour {
	private Counter _deathCounter = new Counter(500);

	private void Update() {
		_deathCounter.Update();

		if (_deathCounter.Value <= 0) {
			Destroy(gameObject);
		}
	}
}
