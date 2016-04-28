using UnityEngine;
using UnityEngine.UI;

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

		if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.P)) {
			line++;
		}

		if (line > endAtLine) {
			//Finish and move on to scene.
			DisableTextBox();
			//sceneFadeInOut.EndScene()
			//Application.LoadLevel("Hospital");
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