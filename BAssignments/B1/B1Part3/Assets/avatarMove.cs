using UnityEngine;
using System.Collections;

public class avatarMove : MonoBehaviour {

	Animator anim;
	float v;
	float h;
	int jumpHash = Animator.StringToHash("Jump");
	int runR = Animator.StringToHash("runRight");
	int runL = Animator.StringToHash("runLeft");
	int startRun = Animator.StringToHash("startRun");
	int startWalk = Animator.StringToHash("startWalk");

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		v = Input.GetAxis("Vertical");
		h = Input.GetAxis("Horizontal");
	}
	void FixedUpdate()
	{
		anim.SetFloat ("walking", v);
		anim.SetFloat ("run", v);

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			anim.SetTrigger (runR);
			anim.SetFloat ("runRight", h);

		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			anim.SetTrigger (runL);
			anim.SetFloat ("runLeft", h);
			
		}	
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			anim.SetTrigger (startRun);
			anim.SetFloat ("startRun", v);
			
		}
		if (Input.GetKeyDown (KeyCode.RightShift)) {
			anim.SetTrigger (startWalk);
			anim.SetFloat ("startWalk", v);
			
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetTrigger (jumpHash);
		}
	}
}
