﻿using UnityEngine;
using System;
using System.Collections;

[RequireComponent(typeof(Animator))] 

public class IKControl : MonoBehaviour {

	private Animator animator;

	public bool ikActive = false;
	public Transform lookObj = null;

	void Start () 
	{
		animator = GetComponent<Animator>();
	}

	//a callback for calculating IK
	void OnAnimatorIK()
	{
		if(animator) {

			//if the IK is active, set the position and rotation directly to the goal. 
			if(ikActive) {
				// Set the look target position, if one has been assigned
				if(lookObj != null) {
					animator.SetLookAtWeight(1);
					animator.SetLookAtPosition(lookObj.position);
				}    
					
			}

			//if the IK is not active, set the position and rotation of the hand and head back to the original position
			else {          
				animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,0);
				animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,0); 
				animator.SetLookAtWeight(0);
			}
		}
	}    
}
