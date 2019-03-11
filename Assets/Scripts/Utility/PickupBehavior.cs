using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PickupTypes;

public class PickupBehavior : MonoBehaviour {

	[Header("Snap Variables")]
	public float snapSpeed = 1.0f;
	public float snapTol = 0.3f;

	[Header("Auto-set Variables")]
	public Rigidbody rigid;
	public GameObject player;

	[Header("Player Variables")]
	public bool isHeld = false;

	[Header("Item Variables")]
	public pickupTypes thisItem = pickupTypes.Generic;

	[Header("FMOD Variables")]
	public FMODUnity.StudioEventEmitter sfxEmit;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>(); // get the rigidbody for this item
		player = GameObject.FindWithTag("Player"); // find the player and save that
		sfxEmit = GetComponent<FMODUnity.StudioEventEmitter>(); // grab the FMOD emitter for the plant sound
	}
	
	// Update is called.
	void Update () {
		
	}

	public void killSelf(){
		if(isHeld)
			player.GetComponent<PlayerPickup>().dropObject();
		Destroy(gameObject);
	}
	public void dropMe(){
		rigid.isKinematic = false;
		isHeld = false;
		transform.parent = null;
	}
	public void setType(pickupTypes objType){
		thisItem = objType;
	}

	public IEnumerator snapToPoint(Vector3 point){
		rigid.isKinematic = true;
		isHeld = true;
		player.GetComponent<PlayerMovement>().disableMove();

		while(Vector3.Distance(transform.position, point) >= snapTol){
			Vector3 oldPos = transform.position;
			transform.position = Vector3.Lerp(oldPos, point, snapSpeed * Time.deltaTime);
			yield return null;
		}
		
		Debug.Log("done");
		transform.parent = player.transform;
		player.GetComponent<PlayerMovement>().enableMove();
	}


	public void OnTriggerEnter(Collider col){
		if(col.tag == "Farm" && (thisItem == pickupTypes.Seed) && !isHeld){
			sfxEmit.Play();
			col.gameObject.GetComponent<FarmPlotBehavior>().plantSeed();
			killSelf();
		}
	}
}
