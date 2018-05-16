using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour {
	public List<GameObject> ComponentList = new List<GameObject>();
	
	public Transform InventoryGrid;

	private List<Transform> _inventorySlots = new List<Transform>();
	private List<GameObject> _inventoryContents = new List<GameObject>();

	private void Awake() {
		InventoryGrid = GameObject.Find("PlayerPrefab").transform.Find("Grid").transform;
	}

	void Start () {
		foreach (var child in InventoryGrid.GetComponentsInChildren<Transform>()) {
			if (child.name != "Grid") {
				_inventorySlots.Add(child);
			}
		}
	}

	public bool IsSlotFree(int slot) {
		try {
			var temp = _inventorySlots[slot];
			return true;
		}
		catch (ArgumentOutOfRangeException e) {
			// Console.WriteLine(e);
			return false;
		}
	}

	public void AddItem(GameObject item) {
		Debug.Log(string.Format("Picked Up: {0}", item));
		
		var num = 0;
		while (!IsSlotFree(num)) {
			num += 1;
		}

		var position = _inventorySlots[num].position;
		Instantiate(item, InventoryGrid.Find(_inventorySlots[num].name));
		
		_inventoryContents.Add(item);
	}
}
