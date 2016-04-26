using UnityEngine;
using System.Collections;

public class LoadScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Application.LoadLevel("Hospital");
		}
		if(Input.GetKeyDown (KeyCode.X)) {
			Application.LoadLevel("Livingroom");
		}
	}
}
