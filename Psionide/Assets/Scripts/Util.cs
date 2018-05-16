using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {
	public static bool IsDead = false;
	
	public static RaycastHit2D RayHitTarget(Vector3 position, Vector3 direction) {
		var hit = Physics2D.Raycast(position, direction, float.MaxValue);

		return hit;
	}
	
	public static Vector3 RayHitPoint(Vector3 position, Vector3 direction) {
		var hit = RayHitTarget(position, direction);

		if (hit.collider != null) {
			return hit.collider.transform.position;
		}
		
		Debug.Log("Did not hit!");
        
		return new Vector3(0, 0, 0);
	}

	public static string CollidedSide<T>(T collision, Transform transform) {
		// Vector2 direction;
		GameObject gameObject;
		if (typeof(T) == typeof(Collider2D)) {
			var collision2D = (Collider2D) (object) collision;
			// direction = transform.InverseTransformDirection(collision2D.transform.position);
			gameObject = collision2D.gameObject;
		}
		else {
			var collision2D = (Collision2D) (object) collision;
			// direction = transform.InverseTransformDirection(collision2D.transform.position);
			gameObject = collision2D.gameObject;
		}
		
		
		/*if (direction.x > 0f) {
			return "right";
		} else if (direction.x < 0f) {
			return "left";
		}

		if (direction.y > 0f) {
			return "up";
		} else if (direction.y < 0f) {
			return "down";
		}*/

		if (gameObject.CompareTag("RightWall")) {
			return "right";
		}
		else if (gameObject.CompareTag("LeftWall")) {
			return "left";
		}
		else if (gameObject.CompareTag("UpWall")) {
			return "up";
		}
		else if (gameObject.CompareTag("DownWall")) {
			return "down";
		}

		return "";
	}

	public static bool IsWall(GameObject gameObject) {
		if (gameObject.CompareTag("RightWall") ||
		    gameObject.CompareTag("LeftWall") ||
		    gameObject.CompareTag("UpWall") ||
		    gameObject.CompareTag("DownWall")) {
			return true;
		}
		return false;
	}

	public static void BounceDiagonally(Transform transform, Rigidbody2D rigidbody2D, float speed) {
		Debug.Log(transform.position);

		if (transform.position.y < 0) {
			rigidbody2D.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
		} else {
			rigidbody2D.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
		}
	}
}
