using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public Transform Target;
	public Transform Shooter;
	public float BulletSpeed = 0f;

	private Vector3 _targetLocation;
	private CameraShakeScript _cameraShake;
	private Rigidbody2D _rigidbody2D;

	private void Awake() {
		_cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeScript>();
	}

	private void Start() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_targetLocation = Target.position;
	}

	private void Update() {
		var step = BulletSpeed * Time.deltaTime;
		
		var angle = Vector3.Angle(Shooter.position, _targetLocation);
		var newDirection = new Vector3(Mathf.Sin(angle), -Mathf.Cos(angle), 0);
		
		var newPosition = Util.RayHitPoint(transform.position, newDirection);
		transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
		
		// _rigidbody2D.AddForce(newPosition * step);
		
		Debug.DrawRay(newPosition, Shooter.position, Color.blue);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Player")) {
			_cameraShake.Shake(x: 0.2f, y: 0.2f);
			Destroy(gameObject);
		}
	}
}
