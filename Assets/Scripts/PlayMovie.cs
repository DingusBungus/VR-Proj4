using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayMovie : MonoBehaviour {
	public MovieTexture movie;

	void Start() {
	GetComponent<RawImage> ().texture = movie as MovieTexture;
	movie.Play ();

	}
}