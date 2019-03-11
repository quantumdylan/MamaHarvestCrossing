using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PickupTypes;

public class SpawnerBehavior : MonoBehaviour {

	[Header("What to Spawn")]
	public GameObject toSpawn;

	[Header("Where to Spawn")]
	public Vector3 spawnLocation;

	[Header("What's been Spawned")]
	public List<GameObject> spawnedObj = new List<GameObject>();

	// Use this for initialization
	void Start () {
		spawnLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnNew(int objType){
		pickupTypes temp = (pickupTypes)objType;
		spawnedObj.Add(Instantiate(toSpawn, spawnLocation, Quaternion.identity));
		spawnedObj[spawnedObj.Count - 1].GetComponent<PickupBehavior>().setType(temp);
	}
	public void removeLast(){
		if(spawnedObj.Count - 1 >= 0){
			spawnedObj[spawnedObj.Count - 1].GetComponent<PickupBehavior>().killSelf();
			spawnedObj.RemoveAt(spawnedObj.Count - 1);
		}
	}
}
