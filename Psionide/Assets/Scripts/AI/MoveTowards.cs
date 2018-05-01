using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour {
	[Range(0.1f, 10f)]
	public float Speed = 5f;
	
	public Transform Target;

	private bool _isMoving = true;
	
	void Update () {
		var step = Speed * Time.deltaTime;
		
		if (_isMoving) {
			transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
		}
	}
}
