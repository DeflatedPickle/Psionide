using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionChanger : MonoBehaviour {
	public float Resolution;
	public ScreenOrientation ScreenOrientation;
	
	void Start () {
		Camera.main.aspect = Resolution;
		Screen.orientation = ScreenOrientation;
	}
}
