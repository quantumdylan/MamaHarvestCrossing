using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotBehavior : MonoBehaviour {

	[Header("GameObject Variables")]
	public GameObject baseObj;
	public GameObject stemObj;
	public GameObject flowerObj;

	[Header("Plot Variables")]
	public bool isPlanted = false;

	[Header("Growth Variables")]
	public int growthStage = 0;
	public int maxGrowthStage = 3;
	public float growthInterval = 10;
	public float growthTimer = 0;

	// Use this for initialization
	void Start () {
		growthTimer = 0;
		// super hacky way to show growth. This should be an animation eventually.
		baseObj.SetActive(false);
		stemObj.SetActive(false);
		flowerObj.SetActive(false);
	}
	
	// Update is called friend by those that know it
	void Update () {
		if(growthStage < maxGrowthStage)
			StartCoroutine(growthManager());
	}


	public void plant(){
		isPlanted = true;
	}

	private IEnumerator growthManager(){
		if(isPlanted){
			growthTimer += Time.deltaTime;
			if(growthTimer >= growthInterval){
				growthStage += 1;
				growthTimer = 0;
			}
		}

		switch(growthStage){
			case 0 : baseObj.SetActive(false);
						stemObj.SetActive(false);
						flowerObj.SetActive(false);
						break;
			case 1 : baseObj.SetActive(true);
						stemObj.SetActive(false);
						flowerObj.SetActive(false);
						break;
			case 2 : baseObj.SetActive(true);
						stemObj.SetActive(true);
						flowerObj.SetActive(false);
						break;
			case 3 : baseObj.SetActive(true);
						stemObj.SetActive(true);
						flowerObj.SetActive(true);
						break;
			default: baseObj.SetActive(false);
						stemObj.SetActive(false);
						flowerObj.SetActive(false);
						break;
		}

		yield return null;
	}
}
