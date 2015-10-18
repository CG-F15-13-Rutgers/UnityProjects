using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class test2 : MonoBehaviour {

	public Text inside; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		inside.text = test1.lkl.ToString();
	}
}
