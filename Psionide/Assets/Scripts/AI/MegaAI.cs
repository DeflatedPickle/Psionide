using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaAI : GenericAI {
	public Transform Bullet;
	
	private Animator _animator;
	private MegaStateMachine _megaStateMachine;
	public ShootAt ShootAt;
	
	private void Awake() {
		_animator = GetComponent<Animator>();
		ShootAt = gameObject.AddComponent<ShootAt>();
		
		_megaStateMachine = _animator.GetBehaviour<MegaStateMachine>();
		_megaStateMachine.MegaAi = this;
		
		ShootAt.Target = GameObject.Find("PlayerPrefab").transform;
		ShootAt.Shooter = transform;
		ShootAt.Bullet = Bullet;
		ShootAt.BulletSpeed = 5f;
		ShootAt.Interval = 150f;
	}

	private void Update() {
		if (ShootAt.Target != null) {
			Debug.DrawLine(transform.position, ShootAt.Target.position, Color.red);
		}
	}
}
