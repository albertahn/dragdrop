using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceableBuilding : MonoBehaviour {





	//[HideInInspector]

	public List <Collider> colliders = new List<Collider>();
	private bool isSelected;


	void OnGUI(){

		if(isSelected){
			GUI.Button(new Rect(100,200,100,30), name);

		}

	}//end gui


	void OnTriggerEnter(Collider c){

		if(c.tag == "Building"){
			colliders.Add(c);
		}//if


		//Debug.Log("ontriggerenter");

	}//ontrigger


	void OnTriggerExit(Collider c){

		if(c.tag == "Building"){
			colliders.Remove(c);


		}//endif

		//Debug.Log("oeit");


	}//exit

	public void SetSelected(bool s){

		isSelected = s;

	}//end

}//end class
