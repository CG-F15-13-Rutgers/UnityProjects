using UnityEngine;
using System.Collections;

public class RayCaster : MonoBehaviour {
	public Transform colliderObj;
	public GameObject Snake;
	bool move = false;

	void Start(){
		Snake.GetComponent<MoveTo>().enabled = false;
		print ("********************************");
		Snake.GetComponent<MoveToClickPoint>().enabled = false;
	}
	// Update is called once per frame
	void Update () {
		bool foundHit = false;

		RaycastHit hit = new RaycastHit ();

		Ray ray = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			colliderObj = hit.transform;
			if(colliderObj.tag == "Agent"){
				print("found AGENT");
				if(Input.GetMouseButtonDown(0)){
					if(move == false){
						move = true;
						Snake.GetComponent<MoveTo>().enabled = true;
						Snake.GetComponent<MoveToClickPoint>().enabled = true;
						print("script is ACTIVE");
					}
					else if(move == true){
						move = false;
						Snake.GetComponent<MoveTo>().enabled = false;
						Snake.GetComponent<MoveToClickPoint>().enabled = false;
						print("script is inactive");
					}
					print("clicked mouse");
				}

			}
			print ("found collider");
		}
		else
			print("nothing"); 

	}
}
