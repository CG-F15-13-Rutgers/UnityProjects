using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public GameObject player1;
	public GameObject player2;
	public float avg;
	private Vector3 offset;

	void Start () {
		offset = transform.position - ((player1.transform.position + player2.transform.position) / 2);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = ((player1.transform.position + player2.transform.position) / 2) + offset;
	}
}
