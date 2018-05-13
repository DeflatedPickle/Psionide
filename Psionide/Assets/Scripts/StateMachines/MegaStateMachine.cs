using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaStateMachine : StateMachineBehaviour {
	public MegaAI MegaAi;

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// Debug.Log(MegaAi);
		
		if (stateInfo.IsTag("MegaShoot")) {
			MegaAi.ShootAt.Shoot();
		}
		else if (stateInfo.IsTag("MegaDeath")) {
			// For some reason MegaAi is always null here, fix this
			// Destroy(MegaAi.gameObject);
		}
	}
}
