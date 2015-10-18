using UnityEngine;
using System.Collections;

public class RayCaster : MonoBehaviour {
	public Transform colliderObj;
	public GameObject obstacle1;
	public GameObject obstacle2;

	void Start(){
		obstacle1.GetComponent<ObstacleController>().enabled = false;
		obstacle2.GetComponent<ObstacleController>().enabled = false;
	}
	// Update is called once per frame
	void Update () {

		RaycastHit hit = new RaycastHit ();

		Ray ray = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			colliderObj = hit.transform;
			if(colliderObj.tag == "Obstacle"){
				print("found Obstacle");
				if(Input.GetMouseButtonDown(0)){
					obstacle1.GetComponent<ObstacleController>().enabled = false;
					obstacle2.GetComponent<ObstacleController>().enabled = false;
					print("clicked mouse");
				}

			}
			print ("found collider");
		}
		else
			print("nothing"); 

	}
}
