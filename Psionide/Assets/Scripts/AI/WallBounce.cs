using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour {
	[Range(0.1f, 10f)]
	public float Speed = 5f;
	
	private Vector3 _direction;

	private float moveXAmount = 6.9f;
	private float moveYAmount = 3.9f;

	private Rigidbody2D _rigidbody2D;

	private void Awake() {
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_direction = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
	}

	void Start () {
		_rigidbody2D.velocity = _direction * Speed;
		// _rigidbody2D.AddForce(_direction * Speed);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("Wall")) {
			Debug.Log(Util.CollidedSide(other, transform));
			switch (Util.CollidedSide(other, transform)) {
				case "right":
					transform.position = new Vector3(moveXAmount, transform.position.y);
					_direction = new Vector3(-_direction.x, _direction.y);
					break;
			
				case "left":
					transform.position = new Vector3(-moveXAmount, transform.position.y);
					_direction = new Vector3(-_direction.x, _direction.y);
					break;
				
				case "up":
					transform.position = new Vector3(transform.position.x, moveYAmount);
					_direction = new Vector3(_direction.x, -_direction.y);
					break;
				
				case "down":
					transform.position = new Vector3(transform.position.x, -moveYAmount);
					_direction = new Vector3(_direction.x, -_direction.y);
					break;
			}
			_rigidbody2D.velocity = _direction * Speed;
			// _rigidbody2D.AddForce(_direction * Speed);
		}
	}
}
