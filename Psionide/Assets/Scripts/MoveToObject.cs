using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToObject : MonoBehaviour {
	public GameObject Object;
	
	void Update () {
		try {
			transform.rotation = Object.transform.rotation;
			transform.position = Object.transform.position;
		}
		catch (MissingReferenceException e) {
			Console.WriteLine(e);
		}
	}
}
