using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetaAI : GenericAI {
	private Animator _animator;
	public WallBounce WallBounce;
	
	private void Awake() {
		_animator = GetComponent<Animator>();
		WallBounce = gameObject.AddComponent<WallBounce>();
		
		WallBounce.Speed = 2f;
	}
}
