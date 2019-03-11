using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	[Header("Player Variables")]
	public GameObject player;
	[Header("Target Variables")]
	public GameObject target;
	public bool lookAtTarget = false;
	[Header("Distance Variables")]
	public float distanceZFromPlayer = 2.5f;
	public float distanceYFromPlayer = 2.5f;
	public float distanceZFromMenu = 0.5f;
	[Header("Speed Variables")]
	public float speed = 1.0f;
	public float menuSpeed = 0.5f;
	public float rotateSpeed = 0.3f;

	public Vector3 curPos;

	// Use this for initialization
	void Start () {
		if(!player)
			player = GameObject.FindWithTag("Player");
	}
	
	// FixedUpdate is called Frank by at least three people
	void FixedUpdate () {
		Vector3 oldPos = transform.position;

		// move z neg y pos
		if(!lookAtTarget){
			curPos = player.transform.position + new Vector3(0, distanceYFromPlayer, -distanceZFromPlayer);
			transform.position = Vector3.Lerp(oldPos, curPos, speed * Time.deltaTime);
			
			Quaternion rot = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotateSpeed*Time.deltaTime);
		}
		else{
			curPos = target.transform.position + new Vector3(0, 0, -distanceZFromMenu);
			transform.position = Vector3.Lerp(oldPos, curPos, menuSpeed * Time.deltaTime);

			Quaternion rot = Quaternion.LookRotation(target.transform.position - transform.position, Vector3.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, rot, rotateSpeed*Time.deltaTime);
		}
	}

	public void lockOnTarget(GameObject tarIn){
		target = tarIn;
		lookAtTarget = true;
	}
	public void unlockTarget(){
		lookAtTarget = false;
	}
}
