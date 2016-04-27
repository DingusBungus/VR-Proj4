using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class Drunk : MonoBehaviour {
	private MotionBlur mBlur;
	float timerDrunk = 3.0f; 

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
		if (mBlur.enabled == true) {
			timerDrunk -= Time.deltaTime;
		}
		if (timerDrunk <= 0) {
			timerDrunk = 3;
			mBlur.enabled = false;
		}
	
	}
}
