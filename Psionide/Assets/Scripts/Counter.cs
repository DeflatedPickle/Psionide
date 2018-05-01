using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {
	public static float Max = 60f;
	public float Step = 1f;

	public bool Stopped = false;
	public string CountDirection = "down";

	private float _current;

	public Counter(float max, float step, string direction) {
		Max = max;
		Step = step;
		CountDirection = direction;

		switch (CountDirection) {
			case "down":
				_current = Max;
				break;
				
			case "up":
				_current = 0;
				break;
		}
	}

	void Update () {
		Debug.Log(_current);

		switch (CountDirection) {
			case "down": 
				if (_current > 0) {
					_current -= Step;
				}
				else {
					Stopped = true;
				}
				break;
				
			case "up":
				if (_current < 0) {
					_current += Step;
				}
				else {
					Stopped = true;
				}
				break;
		}
	}
}
