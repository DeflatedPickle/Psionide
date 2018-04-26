using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {
	public static string CollidedSide(Collision2D collision2D, Transform transform) {
		var direction = transform.InverseTransformDirection(collision2D.transform.position);
		
		if (direction.x > 0f) {
			return "right";
		} else if (direction.x < 0f) {
			return "left";
		}

		if (direction.y > 0f) {
			return "up";
		} else if (direction.y < 0f) {
			return "down";
		}

		return "";
	}
}
