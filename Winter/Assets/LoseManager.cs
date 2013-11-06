using UnityEngine;
using System.Collections;

public class LoseManager : MonoBehaviour {
	
	public wolf wolf_script;
	private bool gameOver;
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameOver = wolf_script.GetGameOver();
		if (gameOver) {
			Application.LoadLevel("Lose");
		}
	}
}
