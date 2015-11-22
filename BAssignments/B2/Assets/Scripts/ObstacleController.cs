using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {
	//private Rigidbody rb;
	//public float speed;

	void Start(){
		//rb=GetComponent<Rigidbody>();
	}

	
	// Update is called once per frame
	void Update () {
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");
		//Vector3 movement= new Vector3(moveHorizontal, 0.0f, moveVertical);
		//rb.AddForce(movement*speed);
		//transform.Translate (1f*Time.deltaTime, 0f,0f);
		transform.Translate (Input.GetAxis("Horizontal")*Time.deltaTime,0.0f, Input.GetAxis("Vertical")*Time.deltaTime);
		print (Input.GetAxis("Horizontal"));
	}
}
