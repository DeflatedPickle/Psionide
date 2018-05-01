using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour {
	[Range(0.1f, 10f)]
	public float Speed = 5f;
	public bool Charge;
	
	public readonly int ChargeLength = 60;
	public readonly int WaitLength = 40;
	public readonly int SpeedLength = 100;
	
	public Transform Target;

	private bool _isMoving = true;
	
	private Counter _chargeCounter;
	private Counter _waitingCounter;
	private Counter _speedCounter;

	private void Start() {
		_chargeCounter = new Counter(ChargeLength) {Value = 0};

		_waitingCounter = new Counter(WaitLength) {Value = 0};
		_speedCounter = new Counter(SpeedLength, direction: "up");
	}

	void Update () {
		var step = Speed * Time.deltaTime;
		
		_chargeCounter.Update();
		Debug.Log("Charge counter ticking: " + _chargeCounter.Value);

		if (_chargeCounter.Value <= 0) {
			_waitingCounter.Update();
			Debug.Log("Waiting counter ticking: " + _waitingCounter.Value);

			_isMoving = false;

			if (_waitingCounter.Value <= 0) {
				_speedCounter.Update();
				Debug.Log("Speed counter ticking: " + _speedCounter.Value);

				if (_speedCounter.Value > SpeedLength) {
					_chargeCounter.Reset();
					_waitingCounter.Reset();
					_speedCounter.Reset();
					Debug.Log("Resetting counters");
				}
				else if (_speedCounter.Value >= 0) {
					// transform.position = Vector3.MoveTowards(transform.position, Target.position, step * 2);
					_isMoving = true;
					step *= 2;
				}
			}
		}
		
		if (_isMoving) {
			transform.position = Vector3.MoveTowards(transform.position, Target.position, step);
		}
	}
}
