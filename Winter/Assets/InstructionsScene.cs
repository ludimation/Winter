using UnityEngine;
using System.Collections;

public class InstructionsScene : MonoBehaviour {
	public Texture2D instructions;
	
	void OnGUI () {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), instructions);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Application.LoadLevel("pathfinding");	
		}
	}
}
