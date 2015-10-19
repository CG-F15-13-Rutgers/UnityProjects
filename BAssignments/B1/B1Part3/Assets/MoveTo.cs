﻿//MoveTo.cs
using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

	public Transform goal;

	// Use this for initialization
	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.destination = goal.position;
	}
	

}
