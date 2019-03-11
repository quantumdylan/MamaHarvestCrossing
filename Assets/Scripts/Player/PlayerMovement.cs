using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[Header("Speed Variables")]
	public float speed = 5.0f;
	public float maxSpeed = 10.0f;
	public float lookSpeed = 10.0f;

	[Header("State Variables")]
	public bool canMove = true;

	private Rigidbody rigid;
	private Vector3 lastAngle;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called mostly on the telephone
	void Update () {
		Vector3 prevPos = transform.position;
		if(canMove){
			float moveHor = Input.GetAxis("Horizontal");
			float moveVer = Input.GetAxis("Vertical");

			Vector3 move = new Vector3(moveHor*speed, rigid.velocity.y, moveVer*speed);

			//rigid.AddForce(move*speed);
			if(rigid.velocity.magnitude <= maxSpeed)
				rigid.velocity = move;
				

			if((moveHor != 0) || (moveVer != 0)){
				Quaternion rotate = Quaternion.Euler(new Vector3(0, Mathf.Atan2(moveHor, moveVer) * Mathf.Rad2Deg, 0));
				transform.rotation = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * lookSpeed);
				//transform.eulerAngles = new Vector3(0, Mathf.Atan2(moveHor, moveVer) * Mathf.Rad2Deg, 0);
			}
		}
	}

	public void disableMove(){
		canMove = false;
		rigid.velocity = Vector3.zero;
	}
	public void enableMove(){
		canMove = true;
	}
}
