using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastScript : MonoBehaviour {
	public static Vector3 RayHitPoint(Vector3 position, Vector3 direction) {
		var hit = Physics2D.Raycast(position, direction);

		if (hit.collider != null) {
			return hit.collider.transform.position;
		}
        
		return new Vector3(0, 0, 0);
	}
}
