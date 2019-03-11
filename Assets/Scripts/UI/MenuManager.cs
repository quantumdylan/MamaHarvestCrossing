using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

	[Header("Menu Control Variables")]
	public GameObject menu;
	public bool menuActive = false;
	public KeyCode activator;
	public Camera camera;

	// Use this for initialization
	void Start () {
		camera = GameObject.FindWithTag("Camera").GetComponent<Camera>();
	}
	
	// Update is called Bob
	void Update () {
		// Detect the escape keypress here
		if(menu.activeSelf != menuActive)
			menu.SetActive(menuActive);
		if(Input.GetKeyDown(activator))
			menuActive = !menuActive;
	}

	public void closeMenu(){
		menuActive = false;
		camera.GetComponent<CameraFollow>().unlockTarget();
	}
	public void openMenu(){
		menuActive = true;
		camera.GetComponent<CameraFollow>().lockOnTarget(menu);
	}
}
