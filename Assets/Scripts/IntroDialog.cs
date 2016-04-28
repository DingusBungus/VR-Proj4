using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroDialog : MonoBehaviour {

	public GameObject textBox;
	public Text text;
	public int line = 0;
	public int endAtLine = 0; //the last line of text.  If the button is pressed here, move to another scene.
	public TextAsset textFile;
	SceneFadeInOut sceneFadeInOut;
	public string[] textLines;

	public float timeFaded = 8.0f;

	// Use this for initialization
	void Start()
	{
		sceneFadeInOut = new SceneFadeInOut ();

		if (textFile != null) {
			textLines = textFile.text.Split ('\n');
		}
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
		//sceneFadeInOut = script
	}

	// Update is called once per frame
	void Update()
	{
		text.text = textLines[line];

		if (line >= endAtLine) {
			//Finish and move on to scene.
			//sceneFadeInOut.EndScene()
			if (SceneManager.GetActiveScene ().name == "Hospital") {
				DisableTextBox ();
				SceneManager.LoadScene ("HospitalRecovery", LoadSceneMode.Single);
			} else if (SceneManager.GetActiveScene ().name == "HospitalRecovery") {
				if (Input.GetKeyDown (KeyCode.JoystickButton1) || Input.GetKeyDown ("o")) { //Circle
					DisableTextBox ();
					SceneManager.LoadScene ("Livingroom", LoadSceneMode.Single);

				} else if (Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown ("x")) { //X
					DisableTextBox ();
					SceneManager.LoadScene ("Bedroom", LoadSceneMode.Single);
				}
			} else if (SceneManager.GetActiveScene ().name == "Livingroom") {
				if (Input.GetKeyDown (KeyCode.JoystickButton1) || Input.GetKeyDown ("o")) { //Circle
					DisableTextBox ();
					SceneManager.LoadScene ("BedroomEnd", LoadSceneMode.Single);

				} else if (Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown ("x")) { //X
					DisableTextBox ();
					SceneManager.LoadScene ("Bedroom", LoadSceneMode.Single);
				}
			} else if (SceneManager.GetActiveScene ().name == "Bedroom") {
				if (Input.GetKeyDown (KeyCode.JoystickButton1) || Input.GetKeyDown ("o")) { //Circle
					DisableTextBox ();
					SceneManager.LoadScene ("Rehab", LoadSceneMode.Single);

				} else if (Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown ("x")) { //X
					DisableTextBox ();
					SceneManager.LoadScene ("Rehab_OD", LoadSceneMode.Single);
					//Fader
					//fade();
					//sceneFadeInOut.EndScene;
				}
			} else if (SceneManager.GetActiveScene ().name == "BedroomEnd") {
				if (Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown ("x")) {
					SceneManager.LoadScene ("Hospital", LoadSceneMode.Single);
				}
			} else if (SceneManager.GetActiveScene ().name == "Rehab") {
				if (Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown ("x")) {
					SceneManager.LoadScene ("Hospital", LoadSceneMode.Single);
				}
			} else if (SceneManager.GetActiveScene ().name == "Rehab_OD") {
				if (Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown ("x")) {
					SceneManager.LoadScene ("Hospital", LoadSceneMode.Single);
				}
			}
		} else {
			if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.P)) {
				line++;
			}
		}
	}

	public void EnableTextBox()
	{
		textBox.SetActive(true);
	}

	public void DisableTextBox()
	{
		textBox.SetActive(false);
	}

	public void fade() {
		while ((timeFaded -= Time.deltaTime) > 0) {
			Debug.Log (timeFaded);
			sceneFadeInOut.EndScene();
		}
		//timeFaded = 8.0f;
	}
}