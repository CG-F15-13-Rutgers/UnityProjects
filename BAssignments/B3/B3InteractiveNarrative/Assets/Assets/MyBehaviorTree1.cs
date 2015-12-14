using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TreeSharpPlus;

public class MyBehaviorTree1 : MonoBehaviour
{
	public Transform wander1;
	public Transform wander2;
	public Transform wander3;
	List<GameObject> characters = new List<GameObject> ();
	public GameObject participant1;
	public GameObject participant2;
	int count;

	private BehaviorAgent behaviorAgent;
	// Use this for initialization
	void Start ()
	{
		characters.Add(participant1);
		characters.Add(participant2);
		int sizeofList = characters.Count;
		print (sizeofList);
		count = 0;
		behaviorAgent = new BehaviorAgent (this.BuildTreeRoot ());
		BehaviorManager.Instance.Register (behaviorAgent);
		behaviorAgent.StartBehavior ();

	}

	protected Node ST_ApproachAndWait(Transform target)
	{

		//foreach (GameObject n in this.characters){
		Val<Vector3> position = Val.V (() => target.position);

		int n = this.count % characters.Count;
		print (n + " count = " + this.count);
		this.count++;
		if (n == 0) {
			print( "decision "+ 1);
			return new Sequence (participant1.GetComponent<BehaviorMecanim> ().Node_GoTo (position), new LeafWait (1000));
		}
		else {
			print( "decision "+ 2);
			return new Sequence (participant2.GetComponent<BehaviorMecanim> ().Node_GoTo (position), new LeafWait (1000));
		}
		//}
		//yield break;
		/*Val<Vector3> position = Val.V (() => target.position);
		return
		new DecoratorLoop (
			new SequenceShuffle (

			new Sequence( participant1.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000)),
			new Sequence( participant2.GetComponent<BehaviorMecanim>().Node_GoTo(position), new LeafWait(1000)))); */
	} 
	
	protected Node BuildTreeRoot()
	{

		return
		new DecoratorLoop (
			new SequenceShuffle (
				//this.ST_ApproachAndWait (this.participant2),
				//this.ST_ApproachAndWait (this.participant3),
				//this.ST_ApproachAndWait (this.participant4)));
				this.ST_ApproachAndWait(wander1),
				this.ST_ApproachAndWait(wander2),
				this.ST_ApproachAndWait(wander3)));
		//print ("Action");
		//return t;


	}
	
}