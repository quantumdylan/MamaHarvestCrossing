using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	[Header("Menu Variables")]
	public GameObject spawnMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider col){
		if(col.tag == "Vending")
			spawnMenu.GetComponent<MenuManager>().openMenu();
		Debug.Log("Enter");
	}
	private void OnTriggerExit(Collider col){
		if(col.tag == "Vending")
			spawnMenu.GetComponent<MenuManager>().closeMenu();
	}
}
