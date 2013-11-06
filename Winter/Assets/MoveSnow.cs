using UnityEngine;
using System.Collections;

public class MoveSnow : MonoBehaviour { // Moves the snow when a player collides with it
	
	public float force_mag = 5f;
	public ParticleEmitter snow;
	public float reset_wind = 10f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (reset_wind > 0) {
			reset_wind -= Time.deltaTime;	
		}
		
		if (reset_wind < 0) {
			reset_wind = 0;	
		}
		
		if (reset_wind == 0) {
			
		}
	}
	
	void OnParticleCollision(GameObject go) {
		Rigidbody body = go.rigidbody;
		if (body) {	// lol if there is a game object;
			Vector3 direction = go.transform.position - transform.position;
			direction = direction.normalized;
			Debug.Log("Force Added, Collision with snow");
			body.AddForce(direction * force_mag);
		}
	}
}
