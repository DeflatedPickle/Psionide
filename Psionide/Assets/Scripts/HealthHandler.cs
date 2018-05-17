using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHandler : MonoBehaviour {
	public int TotalHealth;

	private int _currentHealth;

	public void Damage(int amount) {
		_currentHealth -= amount;
	}

	public void Heal(int amount) {
		_currentHealth += amount;
	}

	public int GetHealth() {
		return _currentHealth;
	}
}
