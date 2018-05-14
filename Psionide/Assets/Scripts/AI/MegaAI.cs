using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaAI : MonoBehaviour {
	public Transform Bullet;
	
	private Animator _animator;
	private MegaStateMachine _megaStateMachine;
	public ShootAt ShootAt;

	private Counter _deathCounter = new Counter(500);
	
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
		if (!Util.IsDead) {
			_deathCounter.Update();
		}

		if (_deathCounter.Value <= 0) {
			// _animator.SetTrigger("MegaDeath");
			Destroy(gameObject);
		}

		if (ShootAt.Target != null) {
			Debug.DrawLine(transform.position, ShootAt.Target.position, Color.red);
		}
	}
}
