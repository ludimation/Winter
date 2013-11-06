using UnityEngine;
using System.Collections;

public class LoseScene : MonoBehaviour {
	public Texture2D lose_texture;
	
	void OnGUI () {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), lose_texture);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Application.LoadLevel("Intro");	
		}
	}
}
