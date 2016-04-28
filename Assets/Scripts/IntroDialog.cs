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

	// Use this for initialization
	void Start()
	{
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
					//TODO: Set bool to where no pill bottle is present
					SceneManager.LoadScene ("Bedroom", LoadSceneMode.Single);

				} else if (Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown ("x")) { //X
					DisableTextBox ();
					SceneManager.LoadScene ("Rehab", LoadSceneMode.Single);
				}
			} else if (SceneManager.GetActiveScene ().name == "Bedroom") {
				if (Input.GetKeyDown (KeyCode.JoystickButton1) || Input.GetKeyDown ("o")) { //Circle
					DisableTextBox ();
					SceneManager.LoadScene ("Rehab", LoadSceneMode.Single);

				} else if (Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown ("x")) { //X
					DisableTextBox ();
					SceneManager.LoadScene ("Overdose", LoadSceneMode.Single);
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
}