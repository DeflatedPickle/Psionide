using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctetAI : GenericAI {
	private MoveTowards _moveTowards;
	
	private void Awake() {
		_moveTowards = gameObject.AddComponent<MoveTowards>();
	}

	private void Update() {
		_moveTowards.Speed = 2f;
		_moveTowards.Charge = true;
		_moveTowards.Target = GameObject.Find("PlayerPrefab").transform;
	}
}
