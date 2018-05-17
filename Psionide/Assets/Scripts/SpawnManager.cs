using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour {
	public Transform KiloPrefab;
	public Transform MegaPrefab;
	public Transform PetaPrefab;

	private readonly Counter _kiloCounter = new Counter(700);
	private readonly Counter _megaCounter = new Counter(1000);
	private readonly Counter _petaCounter = new Counter(1200);
	
	private Transform Player;

	private void Awake() {
		Player = GameObject.Find("PlayerPrefab").transform;
	}

	void Update () {
		if (!Util.IsPaused) {
			_kiloCounter.Update();
			Debug.Log(_kiloCounter.Value);
			_megaCounter.Update();
			_petaCounter.Update();
		}

		if (_kiloCounter.Value <= 0) {
			Instantiate(KiloPrefab, NewPosition(), Quaternion.Euler(0, 0, 0));
			_kiloCounter.Reset();
		}

		if (_megaCounter.Value <= 0) {
			Instantiate(MegaPrefab, NewPosition(), Quaternion.Euler(0, 0, 0));
			_megaCounter.Reset();
		}

		if (_petaCounter.Value <= 0) {
			Instantiate(PetaPrefab, NewPosition(), Quaternion.Euler(0, 0, 0));
			_petaCounter.Reset();
		}
	}

	private Vector3 NewPosition() {
		var x = Random.Range(-7f, 7f);
		var y = Random.Range(-3f, 3f);

		var xDistance = Vector2.Distance(new Vector2(x, 0), new Vector2(Player.position.x, 0));
		var yDistance = Vector2.Distance(new Vector2(y, 0), new Vector2(Player.position.y, 0));

		if (xDistance < -1f || xDistance < 1f) {
			Debug.Log(string.Format("The x is the same as or near the players: {0} - {1}", x, xDistance));
			// return new Vector3(8000, 8000);
		}

		if (yDistance < -1f || yDistance < 1f) {
			Debug.Log(string.Format("The y is the same as or near the players: {0} - {1}", y, yDistance));
			// return new Vector3(8000, 8000);
		}
		
		Debug.Log(string.Format("Not spawning on the player: x - {0}, y - {1}", x, y));
		
		return new Vector3(x, y);
	}
}
