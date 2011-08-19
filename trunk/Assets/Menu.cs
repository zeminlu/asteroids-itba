using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public float buttonWidth;
	public float buttonHeight;
	public float buttonSeparation;
	public float buttonsQty;
	public GUISkin skin;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		GUI.BeginGroup(new Rect((Screen.width >> 1) - (((int)buttonWidth + 20) >> 1), (Screen.height >> 1) - ((int)(200 + (buttonHeight + buttonSeparation) * buttonsQty) >> 1),  buttonWidth + 20, 200 + (buttonHeight + buttonSeparation) * buttonsQty));		
		
		GUI.Box(new Rect(0, 0, buttonWidth + 20, 150 + (buttonHeight + buttonSeparation) * buttonsQty), "Menu", skin.window);
		
		if(GUI.Button(new Rect(10, 100 + buttonSeparation, buttonWidth, buttonHeight), "Restart", skin.button)) {
			Application.LoadLevel("Scene1");
		}
		//if(GUI.Button(new Rect(10, buttonSeparation + 50 +(buttonSeparation + buttonHeight), buttonWidth, buttonHeight), "Quit", skin.button)) {
		//	Application.Quit();
		//}
		
		GUI.EndGroup();
	}
}
