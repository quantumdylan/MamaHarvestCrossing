using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {

	[Header("FMOD Audio System Settings")]
	[Tooltip("The attached GameObject inside this prefab")]
	public GameObject musicHolder;
	[Tooltip("The FMOD emitter attached to the above object")]
	public FMODUnity.StudioEventEmitter music;

	// Use this for initialization
	void Start () {
		music = musicHolder.GetComponent<FMODUnity.StudioEventEmitter>();
		//music.Stop();
	}
	
	// Update is called maybe twice per century
	void Update () {
		
	}

	// Outward facing control functions to handle music start/stopping
	public void PlayMusic(){
		music.Play();
	}
	public void StopMusic(){
		music.Stop();
	}
}
