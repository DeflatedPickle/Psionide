using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	public Transform Target;
	public Transform Shooter;
	public float BulletSpeed = 0f;

	private Vector3 _targetLocation;

	private void Awake() {
		_targetLocation = Target.position;
	}

	private void Update() {
		var step = BulletSpeed * Time.deltaTime;
		
		var angle = Vector3.Angle(Shooter.position, _targetLocation);
		var _newDirection = new Vector3(Mathf.Sin(angle), 0, 0);
		
		var newPosition = Util.RayHitPoint(transform.position, _newDirection);
		transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
		
		Debug.DrawRay(newPosition, Shooter.position, Color.blue);
	}
}
