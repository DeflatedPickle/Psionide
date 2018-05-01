using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter {
	public static float Max = 60f;
	public float Step = 1f;

	public bool Stopped = false;
	public string CountDirection = "down";

	public float Value;

	public Counter(float max, float step = 1, string direction = "down") {
		Max = max;
		Step = step;
		CountDirection = direction;
		
		Reset();
	}

	public void Update () {
		// Debug.Log(Value);

		switch (CountDirection) {
			case "down": 
				if (Value >= 0) {
					Value -= Step;
				}
				else {
					Stopped = true;
				}
				break;
				
			case "up":
				if (Value <= Max) {
					Value += Step;
				}
				else {
					Stopped = true;
				}
				break;
		}
	}

	public void Reset() {
		switch (CountDirection) {
			case "down":
				Value = Max;
				break;
				
			case "up":
				Value = 0;
				break;
		}
	}
}
