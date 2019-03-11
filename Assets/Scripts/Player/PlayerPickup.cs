using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {

	[Header("Target GameObject Variables")]
	public GameObject pickedUp;
	public GameObject pickupTarget;
	
	[Header("State Variables")]
	public bool hasPickedUp = false;

	[Header("Keypress Variables")]
	public KeyCode pickupKey;
	public KeyCode dropKey;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(pickupKey) && hasPickedUp)
			dropObject();
	}

	public bool hasObject(){
		return hasPickedUp;
	}

	public void dropObject(){
		hasPickedUp = false;
		pickedUp.GetComponent<PickupBehavior>().dropMe();
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Pickup" && !hasPickedUp){
			pickedUp = col.gameObject;
			Debug.Log("beep");
			StartCoroutine(col.GetComponent<PickupBehavior>().snapToPoint(pickupTarget.transform.position));
			hasPickedUp = true;
		}
	}
}
