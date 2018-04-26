using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {
	public static RaycastHit2D RayHitTarget(Vector3 position, Vector3 direction) {
		var hit = Physics2D.Raycast(position, direction, float.MaxValue);

		return hit;
	}
	
	public static Vector3 RayHitPoint(Vector3 position, Vector3 direction) {
		var hit = RayHitTarget(position, direction);

		if (hit.collider != null) {
			return hit.collider.transform.position;
		}
        
		return new Vector3(0, 0, 0);
	}

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
