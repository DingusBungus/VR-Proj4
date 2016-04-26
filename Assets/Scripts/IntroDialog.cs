using UnityEngine;
using UnityEngine.UI;

public class IntroDialog : MonoBehaviour {

	public GameObject textBox;
	public Text text;
	public int line = 0;
	public int endAtLine = 0; //the last line of text.  If the button is pressed here, move to another scene.

	public string[] ScriptLines = 
	{
		//(start up in village, Creator talks to you)

		"Doctor, I don't feel so good"	//1

		,"Uhhhhhhh..."	//2

		,"Doctor: Take some pills"	//2

		,"Thanks"	//3

		,"Doctor: Only take them once a day"	//4

		,"I feel much better now"	//5

		,"Goodbye" //6


	};

	// Use this for initialization
	void Start()
	{
		endAtLine = ScriptLines.Length-1;	//6
	}

	// Update is called once per frame
	void Update()
	{
		text.text = ScriptLines [line];

		if (Input.GetKeyDown (KeyCode.P)) {
			line++;
		}

		if (line > endAtLine) {
			//Finish and move on to scene.
			DisableTextBox();
		}
	}

	public void EnableTextBox()
	{
		textBox.SetActive (true);
	}

	public void DisableTextBox()
	{
		textBox.SetActive (false);
	}
	}
