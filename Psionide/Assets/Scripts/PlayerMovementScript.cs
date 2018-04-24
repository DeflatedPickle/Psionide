using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
	[Range(0, 30)]
	public float Speed = 17;

	private bool _isMoving = false;
	private Vector3 _originalPositon;
	private Vector3 _newPosition;
	private Vector3 _oldDirection;
	private Vector3 _newDirection;

	private Rigidbody2D _rigidbody2D;
	private CameraShakeScript _cameraShake;

	private void Awake() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		
		_cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeScript>();
	}

	void Update () {
		Debug.DrawRay(_originalPositon, _newPosition, Color.red);
		// Debug.Log(_isMoving);
		
		var step = Speed * Time.deltaTime;
		_originalPositon = transform.position;
		var touches = Input.touches;

		if (!_isMoving) {
			if (touches.Length == 1) {
				_isMoving = true;
				var mainFinger = touches[0];

				if (mainFinger.phase == TouchPhase.Began) {
					// _newPosition = mainFinger.position;
					// _newPosition = RaycastScript.RayHitPoint(mainFinger.position);
				}
			}
			else if (Input.GetMouseButtonDown(0)) {
				var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				
				var cameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
				var angle = Vector3.Angle(cameraCenter, mousePosition);
				_newDirection = new Vector3(Mathf.Sin(angle), 0, 0);

				if (_oldDirection.x >= 0.1 && _newDirection.x >= 0.1 || _oldDirection.x <= -0.1 && _newDirection.x <= -0.1) {
					// Debug.Log("Same direction!");
					_newDirection = new Vector3(-Mathf.Sin(angle), 0, 0);
				}

				_oldDirection = _newDirection;
				Debug.Log(angle);
				Debug.Log(_newDirection);
			
				_newPosition = RaycastScript.RayHitPoint(mousePosition, _newDirection);
				
				_isMoving = true;
			}
		}
		
		if (_isMoving) {
			transform.position = Vector3.MoveTowards(transform.position, _newPosition, step);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Wall")) {
			Debug.Log("Hit a wall!");
			
			_cameraShake.Shake(x: 0.2f, y: 0.2f);
			_isMoving = false;
		}
	}
}
