using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
	private static List<Item> _inventory = new List<Item>();
	
	// Design decision bools, to be removed later
	bool allButtons = true;
	bool displayNameDesc = false;

	
	public static List<Item> Inventory {
		get {return _inventory;}
	}
	public void Add(Item newItem) {
		_inventory.Add(newItem);	
	}
	
	public void OnGUI() {
		if (allButtons) {
			if (displayNameDesc)
				GUILayout.BeginArea(new Rect(10,10,500,500));
			else
				GUILayout.BeginArea(new Rect(10,10,200,500));
			
			for (int i = 0; i < _inventory.Count; i++) {
				GUILayout.BeginHorizontal();
				GUI.SetNextControlName("item");
				if (GUILayout.Button(_inventory[i].icon)) {
					_inventory[i].transform.position = this.transform.position;
					_inventory[i].active = true;
					_inventory.Remove(_inventory[i]);
					
					i--;
				}
				else {
					if (displayNameDesc) {
						GUILayout.Box(_inventory[i].itemName);
						GUILayout.EndHorizontal();
						GUILayout.Box(_inventory[i].description);
					}
					else
						GUILayout.EndHorizontal();
				}
			}
			GUILayout.EndArea();
		}
		else {
			Texture[] images = new Texture[_inventory.Count];
			for (int i = 0; i < _inventory.Count; i++) {
				images[i] = _inventory[i].icon;
			}
			GUI.SelectionGrid(new Rect(10,10,200,500), 0, images, 1);
		}
	}
	
	// This allows user to pick up item by pressing E if they are close enough to item
	public void Update() {
		if(Input.GetKeyDown(KeyCode.E)) {
			Item[] items = GameObject.FindObjectsOfType(typeof(Item)) as Item[];
			foreach (Item anItem in items) {
				if (Mathf.Abs(this.transform.position.x - anItem.transform.position.x) < 2 && 
					Mathf.Abs(this.transform.position.y - anItem.transform.position.y) < 10) {
					
					_inventory.Add(anItem);
					anItem.active = false;
				}
			}
		}
	}
}
