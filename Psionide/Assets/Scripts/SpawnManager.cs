using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public Transform MegaPrefab;

	private readonly Counter _megaCounter = new Counter(800);

	void Update () {
		_megaCounter.Update();

		if (_megaCounter.Value <= 0) {
			Instantiate(MegaPrefab, new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f)), Quaternion.Euler(0, 0, 0));
			_megaCounter.Reset();
		}
	}
}
