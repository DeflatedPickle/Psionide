using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	public Transform KiloPrefab;
	public Transform MegaPrefab;

	private readonly Counter _kiloCounter = new Counter(500);
	private readonly Counter _megaCounter = new Counter(800);

	void Update () {
		if (!Util.IsDead) {
			_kiloCounter.Update();
			_megaCounter.Update();
		}

		if (_megaCounter.Value <= 0) {
			Instantiate(MegaPrefab, new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f)), Quaternion.Euler(0, 0, 0));
			_megaCounter.Reset();
		}

		if (_kiloCounter.Value <= 0) {
			Instantiate(KiloPrefab, new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f)), Quaternion.Euler(0, 0, 0));
			_kiloCounter.Reset();
		}
	}
}
