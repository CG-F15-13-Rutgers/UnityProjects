using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour{

	public int distance= 2;
	public int numAgents = 3;
	float spawn = 3f;
	public GameObject agent;
    GameObject[] spawnAgents;
	// Use this for initialization
	//Agent agent;

	void Start () 
	{
		//obj= GetComponent<GameObject>();
		spawnAgents = new GameObject[numAgents];
		//agent = new Agent();
		for(int i = 0; i<numAgents; i++){
			GameObject newAgent;
			newAgent = (GameObject)Instantiate(agent ,transform.position + (transform.right*distance),transform.rotation);
			newAgent.name = i.ToString();
			spawnAgents[i] = newAgent;

			distance +=3;
		}
		print ("spawn in 1:" +spawnAgents[1].transform.position);
		printAgents ();
	}
	void Update()
	{

	}
	void printAgents(){
		for(int i = 0; i<numAgents; i++){
			print ("spawn in index "+i+" has the following name : " +spawnAgents[i].name);
			if(int.Parse(spawnAgents[2].name) == 2)
				print("yes god yes");
	
		}
	}
	
	// Update is called once per frame

}
