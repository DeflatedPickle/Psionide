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
		// _direction = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f));
	}

	void Start () {
		// _rigidbody2D.velocity = _direction * Speed;
		// _rigidbody2D.AddForce(_direction * Speed);
		
		var directionList = new List<Vector2> {new Vector2(-1, -1), new Vector2(-1, 1), new Vector2(1, 1), new Vector2(1, -1)};
		var choice = Random.Range(0, directionList.Count);
		
		_rigidbody2D.AddForce(directionList[choice] * Speed, ForceMode2D.Impulse);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(Util.IsWall(other.gameObject));
		if (Util.IsWall(other.gameObject)) {
			Debug.Log(Util.CollidedSide(other, transform));
			switch (Util.CollidedSide(other, transform)) {
				case "right":
					/*transform.position = new Vector3(moveXAmount, transform.position.y);
					_direction = new Vector3(-_direction.x, _direction.y);*/
					_rigidbody2D.AddForce(Vector2.left * Speed, ForceMode2D.Impulse);
					Util.BounceDiagonally(transform, _rigidbody2D, Speed);
					break;
			
				case "left":
					/*transform.position = new Vector3(-moveXAmount, transform.position.y);
					_direction = new Vector3(-_direction.x, _direction.y);*/
					_rigidbody2D.AddForce(Vector2.right * Speed, ForceMode2D.Impulse);
					Util.BounceDiagonally(transform, _rigidbody2D, Speed);
					break;
				
				case "up":
					/*transform.position = new Vector3(transform.position.x, moveYAmount);
					_direction = new Vector3(_direction.x, -_direction.y);*/
					_rigidbody2D.AddForce(Vector2.down * Speed, ForceMode2D.Impulse);
					Util.BounceDiagonally(transform, _rigidbody2D, Speed);
					break;
				
				case "down":
					/*transform.position = new Vector3(transform.position.x, -moveYAmount);
					_direction = new Vector3(_direction.x, -_direction.y);*/
					_rigidbody2D.AddForce(Vector2.up * Speed, ForceMode2D.Impulse);
					Util.BounceDiagonally(transform, _rigidbody2D, Speed);
					break;
			}
			// _rigidbody2D.velocity = _direction * Speed;
			// _rigidbody2D.AddForce(_direction * Speed);
		}
	}
}
