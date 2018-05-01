using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctetAI : MonoBehaviour {
	private MoveTowards _moveTowards;
	
	private void Awake() {
		_moveTowards = gameObject.AddComponent<MoveTowards>();
	}

	private void Update() {
		_moveTowards.Speed = 1.5f;
		_moveTowards.Target = GameObject.Find("PlayerPrefab").transform;
	}
}
