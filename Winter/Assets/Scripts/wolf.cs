using UnityEngine;
using System;

public class wolf : MonoBehaviour {
	
	//Private member variables
	private float distanceFromPlayer;
	private float velocity;
	private float temperature;
	
	enum CharacterState {
		Sniffing = 0,
		Walking = 1,
		Floating = 2,
	}
	
	private CharacterState charState;
	
	//Public member variables
	public Transform playerTransform;
	public float maxVelocity = 15f;
	public float maxTemp = 100f;
	public float warmingDistance = 20f;
	public float warmingSpeed = 0.1f;
	public float maxCoolingDistance = 35f;
	
		
	void Start () {
		//Fill initial state values
		distanceFromPlayer = PlayerDistance(playerTransform.position);
		velocity = 0;
		charState = CharacterState.Walking;
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
		if(charState == CharacterState.Walking) {
			velocity = maxVelocity * temperature / maxTemp;
		}
		else {
			velocity = 0;	
		}
		
		gameObject.GetComponent<NavMeshAgent>().speed = velocity;
		
	}
	
	int PlayerDistance(Vector3 player_position) {
		//Use 3-D Distance formula to find distance to player
		float x = player_position.x - gameObject.transform.position.x;
		float y = player_position.y - gameObject.transform.position.y;
		float z = player_position.z - gameObject.transform.position.z;
		
		float distance = Mathf.Sqrt((x * x) + (y * y) + (z * z));
		return (int) distance;
	}
	
	public float GetTemp () {
		return temperature;	
	}
}
