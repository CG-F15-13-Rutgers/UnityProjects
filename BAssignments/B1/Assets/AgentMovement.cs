using UnityEngine;
using System.Collections;
/**
 * 1. move when clicked on 
 * 2. move to where the mouse clicks
 * */
public class AgentMovement : MonoBehaviour {
	//Transform target;
	public Camera mainCamera;
	NavMeshAgent nav;
	RaycastHit hit;
	// Use this for initialization
	void Awake()
	{
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
			{
				//colliderObj = hit.transform;
				//if(colliderObj.tag != "Agent")
					nav.destination = hit.point;
				
			}
		}
	}
}
