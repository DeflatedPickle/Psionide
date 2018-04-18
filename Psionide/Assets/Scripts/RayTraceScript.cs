using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTraceScript : MonoBehaviour {
    public static Vector3 RayHitPoint(Vector3 inPosition) {
        var ray = Camera.main.ScreenPointToRay(inPosition);
        RaycastHit rayHit;
        
        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity)) {
            return rayHit.point;
        }
        
        return new Vector3(0, 0, 0);
    }
}
