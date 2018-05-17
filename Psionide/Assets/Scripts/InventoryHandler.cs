using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour {
	public List<GameObject> ComponentList = new List<GameObject>();
	
	public Transform InventoryGrid;

	private List<Transform> _inventorySlots = new List<Transform>(23);
	private List<GameObject> _inventoryContents = new List<GameObject>(23);

	private int _freeSlot = 0;

	private void Awake() {
		// InventoryGrid = GameObject.Find("PlayerPrefab").transform.Find("Grid").transform;
		InventoryGrid = GameObject.Find("Grid").transform;
	}

	void Start () {
		foreach (var child in InventoryGrid.GetComponentsInChildren<Transform>()) {
			if (child.name != "Grid") {
				_inventorySlots.Add(child);
				_inventoryContents.Add(null);
			}
		}
	}

	public void AddItem(GameObject item) {
		Debug.Log(string.Format("Picked Up: {0}", item));

		var itemObject = Instantiate(item, InventoryGrid.Find(_inventorySlots[_freeSlot].name));
		itemObject.transform.position = _inventorySlots[_freeSlot].position;
		itemObject.transform.localScale = new Vector3(1.5f, 1.5f, 0);
		
		_inventoryContents[_freeSlot] = item.gameObject;

		_freeSlot++;
	}
}
