using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAI : MonoBehaviour {
    private HealthHandler _healthHandler;

    private void Awake() {
        _healthHandler = GetComponent<HealthHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(string.Format("AI Triggered With: {0}", other.name));
        
        if (other.transform.CompareTag("PlayerWeapon")) {
            _healthHandler.Damage(other.GetComponent<PlayerWeapon>().Damage);
        }
    }
}
