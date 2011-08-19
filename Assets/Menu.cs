using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public float buttonWidth;
	public float buttonHeight;
	public float buttonSeparation;
	public float buttonsQty;

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		GUI.BeginGroup(new Rect((Screen.width >> 1) - (((int)buttonWidth + 20) >> 1), 10,  buttonWidth + 20, (buttonHeight + buttonSeparation * 2 + 10) * buttonsQty));		
		
		GUI.Box(new Rect(0, 0, buttonWidth + 20,  (buttonHeight + buttonSeparation+ 10) * buttonsQty), "Menu");
		
		if(GUI.Button(new Rect(10, buttonSeparation, buttonWidth, buttonHeight), "Restart")) {
			Application.LoadLevel("Scene1");
		}
		if(GUI.Button(new Rect(10, buttonSeparation + (buttonSeparation + buttonHeight), buttonWidth, buttonHeight), "Quit")) {
			Application.Quit();
		}
		
		GUI.EndGroup();
	}
}
