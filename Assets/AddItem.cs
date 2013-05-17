using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddItem : MonoBehaviour {
	
	public Item[] loot;
	PlayerInventory inventory;
	bool displayLootButton = false;
	
	// Use this for initialization
	void Start () {
		inventory = GetComponent("PlayerInventory") as PlayerInventory;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnGUI() {
		if (displayLootButton) {
			GUILayout.BeginArea(new Rect(0,0,500,500));
			if (GUILayout.Button("Loot!")) {
				GiveLoot();
			}
			GUILayout.EndArea();
		}
	}
	
	public void GiveLoot() {
		for (int x = 0; x < loot.Length; x++) {
			inventory.Add(loot[x]);
		}
	}
}

