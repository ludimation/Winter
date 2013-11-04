using UnityEngine;
using System.Collections;

public class PlayAmbientSound : MonoBehaviour {
	
	public float playChance = 0.01f;
	public AudioSource source;
	public AudioClip[] soundClip;
	public GameObject listener;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float distance = Vector3.Distance(listener.transform.position, transform.position);
		
		if (Random.value < playChance && distance < 35) {
			// Play your sound.
			int clip = (int)Random.Range(0.0f, 2.9f);
			if (!AudioSource.isPlaying)  {
				Debug.Log("Sound Played");
			Debug.Log(clip);
				AudioSource.PlayClipAtPoint(soundClip[clip], transform.position);
			}
		}
	}
}
