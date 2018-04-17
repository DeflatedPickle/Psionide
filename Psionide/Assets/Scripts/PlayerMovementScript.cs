﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
	[Range(0, 30)]
	public float Speed = 10;

	private bool _isMoving = false;
	private Vector3 _originalPositon;
	private Vector3 _newPosition;

	private CameraShakeScript _cameraShake;

	private void Awake() {
		_cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeScript>();
	}

	void Update () {
		var step = Speed * Time.deltaTime;
		
		_originalPositon = transform.position;
		
		var touches = Input.touches;

		if (touches.Length == 1) {
			_isMoving = true;
			
			var mainFinger = touches[0];

			if (mainFinger.phase == TouchPhase.Began) {
				_newPosition = mainFinger.position;
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			_isMoving = true;

			_newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_newPosition.z = 0f;
		}
		
		if (_isMoving) {
			transform.position = Vector3.MoveTowards(transform.position, _newPosition, step);

			if (transform.position == _newPosition) {
				_cameraShake.Shake(x: 0.4f, y: 0.4f);
				_isMoving = false;
			}
		}
	}
}