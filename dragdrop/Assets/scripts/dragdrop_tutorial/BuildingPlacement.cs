
using UnityEngine;

using System.Collections;

public class BuildingPlacement : MonoBehaviour {

	private PlaceableBuilding placeableBuilding;
	private Transform currentBuilding;
	//Vector3 pointcam;

	public LayerMask buildingsMask;

	private bool hasPlaced;

	private PlaceableBuilding placeableBuildingOld ;


	void Start(){


		//buildingsMask = (1 << LayerMask.NameToLayer ("Building"));

	}//start

	void Update (){


		if(currentBuilding != null && !hasPlaced){



			Vector3 m = Input.mousePosition;
			
			m = new Vector3(m.x, m.y, transform.position.y);
			Vector3  pointcam = camera.ScreenToWorldPoint(m);		

			currentBuilding.position = new Vector3(pointcam.x, 0, pointcam.z);

			if(Input.GetMouseButtonDown(0)){
				if(IsLegalPosition()){

					
					hasPlaced = true;
				}//iflega

				//Debug.Log("placeableBuilding.colliders.Count: "+placeableBuilding.colliders.Count);

			}//ifdown


		}else{ //placed before

			
			//Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			//Debug.DrawRay (ray.origin, ray.direction * 100.0f, Color.green);

			if(Input.GetMouseButtonDown(0)){

				Vector3 m = Input.mousePosition;
				
				m = new Vector3(m.x, m.y, transform.position.y);
				Vector3  pointcam = camera.ScreenToWorldPoint(m);	

				RaycastHit hiter = new RaycastHit();


				Debug.DrawRay(transform.position, pointcam, Color.green);

				Ray ray =  new Ray(new Vector3(pointcam.x, 8, pointcam.z), Vector3.down);//Camera.main.ScreenPointToRay (Input.mousePosition);//new Ray(new Vector3(pointcam.x, 8, pointcam.z), Vector3.down);

				if(Physics.Raycast(ray, out hiter, Mathf.Infinity, buildingsMask)){
					if(placeableBuildingOld != null){
						placeableBuildingOld.SetSelected(false);
					}//old false

					hiter.collider.gameObject.GetComponent<PlaceableBuilding>().SetSelected(true);
					placeableBuildingOld = hiter.collider.gameObject.GetComponent<PlaceableBuilding>();


				}else{//endmask

					if(placeableBuildingOld !=null){

						placeableBuildingOld.SetSelected(false);

					}//if

				}//else

			}//if

		}//end else
	
	}//up


	public bool IsLegalPosition(){

		if(placeableBuilding.colliders.Count > 0){

			return false;
		}
			return true;

	}//legal

	public void SetItem(GameObject gameObject){

		hasPlaced = false;
		currentBuilding = ((GameObject)Instantiate(gameObject)).transform;
		placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding>();

	//	Debug.Log ("hasplaced: "+hasPlaced);

	}//set item
	
}//public

