using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
	public GameObject Item;

	private InventoryHandler _inventoryHandler;

	private void Awake() {
		_inventoryHandler = GameObject.FindWithTag("Player").transform.GetComponent<InventoryHandler>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		// Debug.Log(string.Format("Item collided with: {0}", other.name));
		if (other.transform.CompareTag("Player")) {
			_inventoryHandler.AddItem(Item);
			Destroy(gameObject);
		}
	}
}
