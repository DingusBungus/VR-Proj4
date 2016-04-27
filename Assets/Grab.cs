using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour {

	// Use this for initialization

	private Animator animator;
	public Transform RightHand = null;
	public Transform lookObj = null;
	//bool hasJumped = false;


	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();

	}

	// Update is called once per frame
	// Update is called once per frame
	void Update () 
	{
		if (animator)
		{
			AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

			if (Input.GetButton("Fire1")) animator.SetBool("Drink", true);

			if ( (state.IsName("Base Layer.Drinking") || state.IsName("Base Layer.FullJump")) && !animator.IsInTransition(0) )
			{
				animator.SetBool("Drink", false);

				animator.MatchTarget(RightHand.position, RightHand.rotation, AvatarTarget.RightHand, new MatchTargetWeightMask(new Vector3(1, 1, 1), 0), animator.GetFloat("MatchStart"), animator.GetFloat("MatchEnd"));
				//	hasJumped = true;
			}

			//if (hasJumped && state.normalizedTime > 1.2)
			//	{
			//		hasJumped = false;
			//		Application.LoadLevel(0);
			//	}
		}

	}
}
