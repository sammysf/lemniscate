using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyGUI : MonoBehaviour {
	
	public GUISkin mySkin;
		
	public float buttonWidth = 40;
	public float buttonHeight = 40;
	public float closeButtonWidth = 20;
	public float closeButtonHeight = 20;
	
	private float _offset = 10;
	
	// Inventory variables
	private bool _displayInventoryWindow = false;
	private const int INVENTORY_WINDOW_ID = 0;
	private Rect _inventoryWindowRect = new Rect(10, 10, 170, 265);
	//private Vector2 _inventoryWindowSlider = Vector2.zero;
	public float inventoryWindowHeight = 90;
	
	
	// Make inventory draggable
	public void InventoryWindow(int id) {
		GUI.DragWindow();
	}
	
	public void toggleInventoryWindow() {
		_displayInventoryWindow = !_displayInventoryWindow;
	}


	public void OnGUI() {
		GUI.skin = mySkin;
		
		if (_displayInventoryWindow)
			_inventoryWindowRect = GUI.Window(INVENTORY_WINDOW_ID, _inventoryWindowRect, InventoryWindow, "Inventory");
	}
	
	
}
