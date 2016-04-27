using UnityEngine;
using System.Collections;

public class Arms : MonoBehaviour {

	private Animator animator;
	public bool tookPills = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (animator) {
			AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo (0);
			if (Input.GetKeyDown("y")) animator.SetBool("take", true);
			if (state.IsName("Base Layer.PunchRight") && !animator.IsInTransition(0))
			{
				animator.SetBool("take", false);
				tookPills = true;
			}
		}
	}


}
