using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

	private Transform currentBuilding;

	public GameObject[] buildings;
	private BuildingPlacement buildingPlacement;


	// Use this for initialization
	void Start () {

		buildingPlacement = GetComponent<BuildingPlacement> ();

	//	Debug.Log ("hi there: "+buildings.Length);
	
	}//start
	
	// Update is called once per frame
	void Update () {
	
	}//update



	//gui


	void OnGUI(){

	

		for (int i = 0; i < buildings.Length; i ++) {
				
			if(GUI.Button (new Rect(Screen.width/20, Screen.height/15 + Screen.height/12 *i, 100, 30), buildings[i].name)){

				buildingPlacement.SetItem(buildings[i]);


				//Debug.Log ("uildings.Length: " +buildings.Length);
			}//end if
		
		}//end for


	}//gui



}// end class
