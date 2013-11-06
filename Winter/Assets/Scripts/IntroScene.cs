using UnityEngine;
using System.Collections;

public class IntroScene : MonoBehaviour {
	
	public Texture2D intro;
	
	void OnGUI () {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), intro);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Application.LoadLevel("Instructions");	
		}
	}
}
