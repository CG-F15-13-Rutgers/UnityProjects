using UnityEngine;
using System.Collections;

public class MovingDevilsScript : MonoBehaviour {

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3 (Mathf.PingPong (Time.time, 1)+15, transform.position.y, transform.position.z);
	}
}
