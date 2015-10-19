//MoveToClickPoint.cs
using UnityEngine;
using System.Collections;

public class MoveToClickPoint : MonoBehaviour {
	NavMeshAgent nav;
	Animator anim;
	private Transform colliderObj;
	private float lastClickTime;
	public float delay = 0.50f;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float v = Input.GetAxis("Vertical");
		int run = Animator.StringToHash("startRun");
		int walk = Animator.StringToHash ("startWalk");
		int jump = Animator.StringToHash ("Jump");
		if (Input.GetMouseButton (0)) {
			if((Time.time - lastClickTime) < delay)
			{
				RaycastHit hit;
				
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
				{

					anim.SetTrigger (run);
					anim.SetFloat ("startRun", v);
					colliderObj = hit.transform;
					if(colliderObj.tag != "Agent")
					nav.destination = hit.point;

					if(nav.isOnOffMeshLink)
					{
						OffMeshLinkData data = nav.currentOffMeshLinkData;
						Vector3 startPos = nav.transform.position;
						Vector3 endPos = data.endPos + Vector3.up*nav.baseOffset;
						anim.SetTrigger (jump);
						nav.CompleteOffMeshLink();
						nav.Resume();
					}
						
						if (nav.destination == hit.point){
						anim.ResetTrigger(run);
					}

					
					
				}
			} else {
		
				RaycastHit hit;
				if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
				{
					anim.SetTrigger (walk);
					anim.SetFloat ("startWalk", v);
					colliderObj = hit.transform;
					if(colliderObj.tag != "Agent")
					nav.destination = hit.point;
					if (nav.destination == hit.point){
						anim.ResetTrigger(walk);
					}

				}
			} 
			lastClickTime = Time.time;
		}
	}
}
