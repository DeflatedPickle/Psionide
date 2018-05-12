using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaStateMachine : StateMachineBehaviour {
	public MegaAI MegaAi;

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (stateInfo.IsTag("MegaShoot")) {
			MegaAi.ShootAt.Shoot();
		}
		else if (stateInfo.IsTag("MegaDeath")) {
			// Destroy(MegaAi.gameObject);
		}
	}
}
