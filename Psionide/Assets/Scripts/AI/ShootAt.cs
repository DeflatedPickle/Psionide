using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAt : MonoBehaviour {
    public Transform Target;
    public float Inaccuracy;
    public float Interval;

    private Counter _intervalCounter;

    private void Start() {
        _intervalCounter = new Counter(Interval);
    }

    private void Update() {
        _intervalCounter.Update();

        if (_intervalCounter.Value <= 0) {
            Debug.Log("Shooting");
            _intervalCounter.Reset();
        }
    }
}
