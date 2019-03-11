using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlotBehavior : MonoBehaviour {

	[Header("GameObject Variables")]
	public GameObject farmPhysical;
	public GameObject plotPrefab;
	
	[Header("Farm Variables")]
	public float plotsX = 2;
	public float plotsY = 2;
	public List<GameObject> plots = new List<GameObject>();

	// Use this for initialization
	void Start () {
		for(int x = 0; x < plotsX; x++){
			for(int y = 0; y < plotsY; y++){
				Vector3 spawnPointRaw = new Vector3((-1/(plotsX*2))+(1/plotsX)*x, 0, (-1/(plotsY*2))+(1/plotsY)*y); // calculate the fractional relative positions
				Vector3 colliderDim = farmPhysical.GetComponent<Renderer>().bounds.size; // get the collider bounds
				Vector3 spawnScaled = Vector3.Scale(colliderDim, spawnPointRaw); // scale the fractional relative positions to the collider
				Vector3 spawnPoint = spawnScaled + farmPhysical.transform.position; // translate to the farm plot

				plots.Add(Instantiate(plotPrefab, spawnPoint, Quaternion.identity)); // create the individual plot

				plots[plots.Count - 1].transform.parent = transform; // add this to the farmplot object as a child
			}
		}
	}
	
	// Update is called up at around 3 am to start harvesting
	void Update () {
		
	}

	public void plantSeed(){
		Debug.Log("Planting seed.");
		foreach (GameObject plot in plots){
			if(!plot.GetComponent<PlotBehavior>().isPlanted){
				plot.GetComponent<PlotBehavior>().plant();
				break;
			}
		}
	}
}
