﻿using UnityEngine;
using System.Collections;

public class GUIBehavior : MonoBehaviour {
	
	public Texture barTexture;
	public Texture boxTexture;

	public wolf wolfData;
	public int boxWidth = 34;
	public int boxHeight = 30;
	
	void OnGUI () {
		
		Screen.showCursor = false;

		//Print the bar
		GUI.Box (new Rect(Screen.width - barTexture.width - 28,10,barTexture.width + 8, barTexture.height + 18),barTexture);

		//Print the box
		GUI.Box (new Rect(Screen.width - barTexture.width / 2 - 24 - boxWidth / 2
		                  , 18f + .97f * barTexture.height * (100f - wolfData.GetTemp()) / 100f

		                  ,boxWidth,boxHeight), boxTexture);
	}
	
		
	void Update () {
		
		if(Input.GetKey ("t")) {
			Application.LoadLevel("Win");
			print ("STUFF");		
		}
		
		else if (Input.GetKey ("g")) {
			
			Application.LoadLevel("Lose");
			print ("LOSE");

		}
	}
	
}
