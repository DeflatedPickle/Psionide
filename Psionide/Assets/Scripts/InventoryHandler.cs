using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour {
	public List<GameObject> ComponentList = new List<GameObject>();
	
	public Transform InventoryGrid;

	private List<Transform> _inventorySlots = new List<Transform>(23);
	private List<GameObject> _inventoryContents = new List<GameObject>(23);

	private void Awake() {
		InventoryGrid = GameObject.Find("PlayerPrefab").transform.Find("Grid").transform;
	}

	void Start () {
		foreach (var child in InventoryGrid.GetComponentsInChildren<Transform>()) {
			if (child.name != "Grid") {
				_inventorySlots.Add(child);
			}
		}

		for (var i = 0; i < 23; i++) {
			_inventoryContents.Add(null);
		}
	}

	public bool IsSlotFree(int slot) {
		// Debug.Log(_inventoryContents[slot]);
		var items = "";
		foreach (var i in _inventoryContents) {
			items += i + ", ";
		}
		Debug.Log(string.Format("Items: {0}", items));
		
		if (_inventoryContents[slot] == null) {
			return true;
		}

		return false;
	}

	public void AddItem(GameObject item) {
		Debug.Log(string.Format("Picked Up: {0}", item));
		
		var num = 0;
		while (!IsSlotFree(num)) {
			num ++;
		}
		Debug.Log(num);

		var itemObject = Instantiate(item, InventoryGrid.Find(_inventorySlots[num].name));
		itemObject.transform.position = _inventorySlots[num].position;
		
		_inventoryContents[num] = item.gameObject;
	}
}
