//MoveToClickPoint.cs
using UnityEngine;
//using System.Collections;

public class MoveToClickPoint : MonoBehaviour {
	NavMeshAgent nav;
	private Transform colliderObj;
	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			RaycastHit hit;

			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
			{
				colliderObj = hit.transform;
				if(colliderObj.tag != "Agent")
				nav.destination = hit.point;

			}
		}
	}
}
