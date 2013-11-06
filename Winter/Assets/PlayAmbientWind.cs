using UnityEngine;
using System.Collections;

public class PlayAmbientWind : MonoBehaviour {
	
	public AudioClip wind;
	public float time_delay = 1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (time_delay > 0) {
			time_delay -= Time.deltaTime;	
		}
		
		if (time_delay < 0) {
			time_delay = 0;	
		}
		
		if (time_delay == 0) {
			if (!audio.isPlaying) {
				audio.clip = wind;
				audio.Play();
			}
		}
	}
}
