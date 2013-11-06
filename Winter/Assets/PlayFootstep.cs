using UnityEngine;
using System.Collections;

public class PlayFootstep : MonoBehaviour {
	
	private float AudioTimer = 0;
	public AudioClip footstep;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (AudioTimer > 0) {
			AudioTimer -= Time.deltaTime;
		}
		
		if (AudioTimer < 0) {
			AudioTimer = 0;	
		}
	}
	
//	void OnControllerColliderHit (ControllerColliderHit col) {
	void OnTriggerEnter (Collider col) {
	 	if (AudioTimer == 0) {
			Debug.Log("Footstep sound played");
			audio.clip = footstep;
			audio.PlayOneShot (footstep);
			AudioTimer = 0.3f;
		}
	}
}
