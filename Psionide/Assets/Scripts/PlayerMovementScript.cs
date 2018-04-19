using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
	[Range(0, 30)]
	public float Speed = 10;

	private bool _isMoving = false;
	private Vector3 _originalPositon;
	private Vector3 _newPosition;
	private Vector3 _direction;

	private Rigidbody2D _rigidbody2D;
	private CameraShakeScript _cameraShake;
	
	// private bool hasCollided = false;

	private void Awake() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		
		_cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeScript>();
	}

	void Update () {
		// Debug.DrawRay(_originalPositon, _newPosition, Color.red);
		
		var step = Speed * Time.deltaTime;
		
		_originalPositon = transform.position;
		
		var touches = Input.touches;

		if (touches.Length == 1) {
			_isMoving = true;
			
			var mainFinger = touches[0];

			if (mainFinger.phase == TouchPhase.Began) {
				// _newPosition = mainFinger.position;
				// _newPosition = RaycastScript.RayHitPoint(mainFinger.position);
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			_isMoving = true;

			var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			// _newPosition = mousePosition;
			// _newPosition.z = 0f;

			var cameraCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));

			var angle = Vector3.Angle(cameraCenter, mousePosition);
			_direction = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
			
			_newPosition = RaycastScript.RayHitPoint(mousePosition, _direction);
		}
		
		if (_isMoving) {
			transform.position = Vector3.MoveTowards(transform.position, _newPosition, step);

/*			if (transform.position == _newPosition) {
				_cameraShake.Shake(x: 0.2f, y: 0.2f);
				_isMoving = false;
			}*/
			
/*			if (hasCollided) {
				_cameraShake.Shake(x: 0.2f, y: 0.2f);
				_isMoving = false;
				hasCollided = false;
			}*/
		}
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Wall")) {
			_cameraShake.Shake(x: 0.2f, y: 0.2f);
			_isMoving = false;
		}
	}
}
