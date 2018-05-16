using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
	private CameraShakeScript _cameraShake;

	private void Awake() {
		_cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeScript>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (Util.IsWall(other.gameObject) || other.gameObject.CompareTag("Player")) {
			_cameraShake.Shake(x: 0.2f, y: 0.2f);
			Destroy(gameObject);
		}
	}
}
