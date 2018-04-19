using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeScript : MonoBehaviour {
	[Range(0, 60)]
	public static readonly int Counter = 7;
	
	private static float _shakeX = 0.8f;
	private static float _shakeXSpeed = 0.8f;
	
	private static float _shakeY = 0.8f;
	private static float _shakeYSpeed = 0.8f;

	private static bool _shake = false;
	private static int _counter = Counter;
	
	void Update () {
		if (_shake) {
			var newPosition = new Vector2(_shakeX, _shakeY);
		
			if (_shakeX < 0) {
				_shakeX *= _shakeXSpeed;
			}
			_shakeX = -_shakeX;
		
			if (_shakeY < 0) {
				_shakeY *= _shakeYSpeed;
			}
			_shakeY = -_shakeY;
		
			transform.Translate(newPosition);
			
			_counter -= 1;
		}

		if (_counter == 0) {
			_shake = false;
			_counter = Counter;
			transform.position = new Vector3(0, 0, -10);
		}
	}

	public void Shake(float x = 0.8f, float y = 0.8f, float xSpeed = 0.8f, float ySpeed = 0.8f) {
		_shakeX = x;
		_shakeXSpeed = xSpeed;

		_shakeY = y;
		_shakeYSpeed = ySpeed;
		
		_shake = true;
		_counter = Counter;
	}
}
