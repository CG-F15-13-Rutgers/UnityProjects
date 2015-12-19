using UnityEngine;
using System.Collections;
using TreeSharpPlus;
using System.Collections.Generic;
using System.Linq;

using RootMotion.FinalIK;

public class MyBehaviorTree : MonoBehaviour
{
	public Transform wander1;
	public Transform wander2;
	public Transform wander3;
	public Transform wander4;
	public InteractionObject cellphone;
	public GameObject participant1;
	public GameObject participant2;
	public GameObject participant3;


	public bool isCaught;

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

	protected Node ST_Approach(Transform target1, Transform target2, InteractionObject cp)
	{
		//foreach (GameObject n in chara) {
		Val<Vector3> position1 = Val.V (() => target1.position);
		Val<Vector3> position2 = Val.V (() => target2.position);
		//print ("hello");
		return new SequenceParallel (participant2.GetComponent<BehaviorMecanim> ().Node_GoTo (position1), participant1.GetComponent<BehaviorMecanim> ().Node_GoTo (position1));  

	}

	protected Node ST_TurnAround(Transform target2)
	{
		Val<Vector3> position2 = Val.V (() => target2.position);
		return new Sequence (participant2.GetComponent<BehaviorMecanim> ().Node_OrientTowards(position2));
	}

	protected Node ST_Shoot()
	{
			return new SequenceParallel (participant2.GetComponent<BehaviorMecanim> ().Node_HandAnimation ("PISTOLAIM", true), participant1.GetComponent<BehaviorMecanim> ().Node_BodyAnimation ("DYING", true));
	}

	protected Node BuildTreeRoot()
	{

		return
			//new DecoratorLoop(
				new Sequence(
				this.ST_Approach (this.wander1, this.wander2, this.cellphone),
					this.ST_TurnAround(this.wander2),
					this.ST_Shoot()
				//this.ST_PickUp (this.cellphone)
				//this.ST_AttackandDie()
				);
	}
}
