using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Drunk : MonoBehaviour {
	private MotionBlur mBlur;
	float timerDrunk = 4.0f; 
	public Arms arm;

	// Use this for initialization
	void Start () {
		mBlur = GetComponent<UnityStandardAssets.ImageEffects.MotionBlur> ();
		mBlur.enabled = true;
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown ("t")) {
			mBlur.enabled = true;
		}
		if (arm.tookPills){
			timerDrunk -= Time.deltaTime;
			//mBlur.blurAmount -= 0.2f;
		}
		if (timerDrunk <= 0) {
			timerDrunk = 3;
			mBlur.enabled = false;
		}

		//if (arm.tookPills) {
	//		mBlur.enabled = false;
	//	}
	}
}
