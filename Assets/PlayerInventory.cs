using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
	private static List<Item> _inventory = new List<Item>();
	
	// Design decision bools, to be removed later
	bool allButtons = true;
	bool displayNameDesc = false;
	bool shouldRemove = false;
	
	// Inventory related
	public GUISkin mySkin;
	int focusedButton = -1;

	
	public static List<Item> Inventory {
		get {return _inventory;}
	}
	public void Add(Item newItem) {
		_inventory.Add(newItem);	
	}
	
	public void OnGUI() {
		GUI.skin = mySkin;
		if (allButtons) {
			if (displayNameDesc)
				GUILayout.BeginArea(new Rect(10,10,500,500));
			else
				GUILayout.BeginArea(new Rect(10,10,200,500));
			
			for (int i = 0; i < _inventory.Count; i++) {
				GUILayout.BeginHorizontal();
				GUI.SetNextControlName("item" + i.ToString());
				if (GUILayout.Button(_inventory[i].icon)) {
					if (shouldRemove) {					
						//this.transform.position.x = _inventory[i].transform.position.x;  // This is a line that isn't tested
						_inventory[i].active = true;
						_inventory.Remove(_inventory[i]);
						
						i--;
					}
					else {
						if (GUI.GetNameOfFocusedControl() != ("item" + i.ToString())) {
							
							GUI.FocusControl("item" + i.ToString());
							focusedButton = i;
							_inventory[i].isToggled = true;
						}
						else {
							GUIUtility.keyboardControl = 0;
							focusedButton = -1;
							_inventory[i].isToggled = false;
							
						}
					}
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
			if (focusedButton >= 0)
				GUI.FocusControl("item" + focusedButton.ToString());
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
