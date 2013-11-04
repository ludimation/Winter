using UnityEngine;
using System;

public class wolf : MonoBehaviour {
	
	//Private member variables
	private float distanceFromPlayer;
	private float velocity;
	private float temperature;
	
	//Public member variables
	public Transform playerTransform;
	public float maxVelocity;
	public float maxTemp;
	public float warmingDistance;
	public float warmingSpeed;
		
	void Start () {
		//Fill initial state values
		distanceFromPlayer = PlayerDistance(playerTransform.position);
		velocity = 0;
	}
	
	
	void Update () {
		
		//Find distance from player
		distanceFromPlayer = PlayerDistance(playerTransform.position);
		
		//Check bounds for Velocity
		if(velocity > maxVelocity) {
			velocity = maxVelocity;
		}
		if(velocity < 0) {
			velocity = 0;
		}
		
		//Adjust temperature based on player distance
		temperature +=  (warmingDistance - distanceFromPlayer) * Time.deltaTime * warmingSpeed;
		
		//Check bounds on Temperature
		if(temperature > maxTemp) {
			temperature = maxTemp;
		}
		if(temperature < 0) {
			temperature = 0;
		}
		
		//Manage Velocity
		velocity = maxVelocity * temperature / maxTemp;
		
		gameObject.GetComponent<NavMeshAgent>().speed = velocity;
		
	}
	
	int PlayerDistance(Vector3 player_position) {
		//Use 3-D Distance formula to find distance to player
		float x = player_position.x;
		float y = player_position.y;
		float z = player_position.z;
		
		float distance = Mathf.Sqrt((x * x) + (y * y) + (z * z));
		return (int) distance;
	}
}
