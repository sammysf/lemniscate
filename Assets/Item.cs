using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public int id;
	public string itemName;
	public string description;
	public Texture2D icon;
	public bool isToggled;
	
	public void Start() {
		isToggled = false;
	}
	
	public void OnMouseUp() {
		// If player is close enough to item, put item in inventory and remove from scene
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (Mathf.Abs(this.transform.position.x - player.transform.position.x) < 1 && 
			Mathf.Abs(this.transform.position.y - player.transform.position.y) < 10) {
			PlayerInventory inventory = player.GetComponent("PlayerInventory") as PlayerInventory;
			inventory.Add(this);
			this.active = false;
		}
	}
}
