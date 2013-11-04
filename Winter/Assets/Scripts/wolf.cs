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
	public float maxCoolingDistance;
		
	void Start () {
		//Fill initial state values
		distanceFromPlayer = PlayerDistance(playerTransform.position);
		velocity = 0;
	}
	
	
	void Update () {
		float tempDistance;     //Player distance from wolf, but maxes out at 30
		
		//Find distance from player
		tempDistance = distanceFromPlayer = PlayerDistance(playerTransform.position);
		if(tempDistance > maxCoolingDistance) {
			tempDistance = maxCoolingDistance;
		}
		
		//Adjust temperature based on player distance
		temperature +=  (warmingDistance - tempDistance) * Time.deltaTime * warmingSpeed;
		
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
