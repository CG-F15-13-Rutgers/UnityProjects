using UnityEngine;
using System.Collections;
using TreeSharpPlus;
using System.Collections.Generic;
using System.Linq;

public class MyBehaviorTree : MonoBehaviour
{
	public Transform wander1;
	public Transform wander2;
	public Transform wander3;
	public Transform wander4;
	public Transform tv;
	public GameObject participant1;
	public GameObject participant2;
	public GameObject participant3;

	private BehaviorAgent behaviorAgent;
	// Use this for initialization

	void Start ()
	{
		behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behaviorAgent);
		behaviorAgent.StartBehavior ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	protected Node ST_ApproachAndWait(Transform target1, Transform target2, Transform tv)
	{
		//foreach (GameObject n in chara) {
		Val<Vector3> position1 = Val.V (() => target1.position);
		Val<Vector3> position2 = Val.V (() => target2.position);
		Val<Vector3> TVposition = Val.V (() => tv.position);
		//print ("hello");
		return new Sequence (participant1.GetComponent<BehaviorMecanim> ().Node_GoTo (position1), participant1.GetComponent<BehaviorMecanim> ().Node_OrientTowards (TVposition), participant2.GetComponent<BehaviorMecanim> ().Node_GoTo (position2), participant2.GetComponent<BehaviorMecanim> ().Node_OrientTowards (TVposition));  
		                     /*participant2.GetComponent<BehaviorMecanim>().Node_HandAnimation("CLAP", true), participant1.GetComponent<BehaviorMecanim>().Node_HandAnimation("CLAP", true)*/
	}

	protected Node ST_RunUp(Transform target, Transform tv)
	{
		Val<Vector3> position = Val.V (() => target.position);
		Val<Vector3> TVposition = Val.V (() => tv.position);
		return new Sequence (participant3.GetComponent<BehaviorMecanim> ().Node_GoTo (position), participant3.GetComponent<BehaviorMecanim> ().Node_GoTo (position), participant3.GetComponent<BehaviorMecanim>().Node_OrientTowards(TVposition), participant3.GetComponent<BehaviorMecanim> ().Node_HandAnimation ("ROAR", true));
	}

	protected Node ST_Reaction(Transform target, Transform target2)
	{
		Val<Vector3> position = Val.V (() => target.position);
		Val<Vector3> position2 = Val.V (() => target2.position);
		return new Sequence (participant1.GetComponent<BehaviorMecanim> ().Node_OrientTowards (position), participant2.GetComponent<BehaviorMecanim> ().Node_OrientTowards (position), participant1.GetComponent<BehaviorMecanim> ().Node_HandAnimation ("SURPRISED", true), participant2.GetComponent<BehaviorMecanim> ().Node_HandAnimation ("SURPRISED", true), participant1.GetComponent<BehaviorMecanim> ().Node_HandAnimation ("FIGHT", true), participant2.GetComponent<BehaviorMecanim> ().Node_HandAnimation ("CRY", true), participant3.GetComponent<BehaviorMecanim>().Node_NudgeTo(position2));
	}

	protected Node BuildTreeRoot()
	{

		return
			//new DecoratorLoop(
				new Sequence(
				this.ST_ApproachAndWait (this.wander1, this.wander2, this.tv),
				this.ST_RunUp (this.wander3, this.tv),
				this.ST_Reaction (this.wander3, this.wander4)
				//this.ST_ApproachAndWait1(this.wander2, this.tv)
				//this.ST_ApproachAndWait (this.wander2),
				//this.ST_ApproachAndWait (this.wander3)
				//participant1.GetComponent<BehaviorMecanim>().Node_HandAnimation("ADAPTMan@happy_hand_gesture", true)
				);
	}
}
