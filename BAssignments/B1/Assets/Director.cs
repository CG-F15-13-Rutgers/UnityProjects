using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour{
	public GameObject initialPosition;
	public Transform colliderObj;
	bool move = false;
	//NavMeshAgent nav;
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
			newAgent = (GameObject)Instantiate(agent ,initialPosition.transform.position + (initialPosition.transform.right*distance), initialPosition.transform.rotation);
			newAgent.name = i.ToString();
			/*NEW AGENT CREATED AND ON THE FIELD*/
			spawnAgents[i] = newAgent;
			/*disable its navmeshagent until its clicked on*/
			spawnAgents[i].GetComponent<NavMeshAgent>().enabled = false;
			//spawnAgents[i].GetComponent<MoveTo>().enabled = true;
			spawnAgents[i].GetComponent<MoveToClickPoint>().enabled = true;
			distance +=3;
		}

		//printAgents ();
	}
	void Update()
	{
		RaycastHit hit = new RaycastHit ();
		
		Ray ray = GetComponent<Camera>().ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			colliderObj = hit.transform;
			if(colliderObj.tag == "Agent"){
				print("found AGENT");

				if(Input.GetMouseButtonDown(0)){
					/*Retrieve name of specific agent using its name. This is also key to finding it in the list of agents*/
					int index = int.Parse(colliderObj.name);
					if(move == false){
						move = true;
						spawnAgents[index].GetComponent<NavMeshAgent>().enabled = true;
						print("script is ACTIVE");
					}
					else if(move == true){
						move = false;
						spawnAgents[index].GetComponent<NavMeshAgent>().enabled = false;
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


	/*TESTING PURPOSES*/
	void printAgents(){
		for(int i = 0; i<numAgents; i++){
			print ("spawn in index "+i+" has the following name : " +spawnAgents[i].name);
			if(int.Parse(spawnAgents[2].name) == 2)
				print("yes god yes");
	
		}
	}
	
	// Update is called once per frame

}
