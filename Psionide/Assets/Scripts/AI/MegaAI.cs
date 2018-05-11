using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaAI : MonoBehaviour {
	public Transform Bullet;
	
	private ShootAt _shootAt;
	
	private void Awake() {
		_shootAt = gameObject.AddComponent<ShootAt>();
		
		_shootAt.Target = GameObject.Find("PlayerPrefab").transform;
		_shootAt.Shooter = transform;
		_shootAt.Bullet = Bullet;
		_shootAt.BulletSpeed = 5f;
		_shootAt.Interval = 150f;
	}

	private void Update() {
		Debug.DrawLine(transform.position, _shootAt.Target.position, Color.red);
	}
}
