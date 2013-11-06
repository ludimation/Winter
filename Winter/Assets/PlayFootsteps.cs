using UnityEngine;
using System.Collections;

public class PlayFootsteps : MonoBehaviour {
	
	private float AudioTimer = 0.0f;
	public AudioClip[] footstep;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// Create an Audio Timer, so that we aren't calling too many footsteps to the scene.
		if (AudioTimer > 0) {
			AudioTimer -= Time.deltaTime;	
		}
		
		if (AudioTimer < 0) {
			AudioTimer = 0;	
		}
		
	}
	
	void OnTriggerEnter (Collider col) {
		if (AudioTimer == 0) {
			int clip_num = Random.Range(0, footstep.Length);	// Choose a random footstep sound.
			audio.clip = footstep[Random.Range(0, clip_num)];		// Load audio
			audio.Play();	// Play audio
			Debug.Log("Footstep " + clip_num + " Played");	// Log for debug
			AudioTimer = 0.1f;	// Reset Audio timer
		}
	}
}
