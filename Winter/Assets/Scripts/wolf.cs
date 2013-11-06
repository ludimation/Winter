using UnityEngine;
using System;

public class wolf : MonoBehaviour {
	
	//Private member variables
	private float distanceFromPlayer;
	private float velocity;
	private float temperature;
	private bool gameOver;
	private NavMeshAgent agent;
	private float sniffCooldown;
	private bool movingToEnd;
	
	
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
		gameOver = false;
		agent = GetComponent<NavMeshAgent>();
		sniffCooldown = 5f;
		
		Vector3 movVec = new Vector3(
	    	UnityEngine.Random.Range(180,725),
			0,
			UnityEngine.Random.Range(213,840));
		agent.SetDestination(movVec);
		
		movingToEnd = false;
	}
	
	
	void Update () {
		float tempDistance;     //Player distance from wolf, but maxes out at maxCoolingDistance
		
		//Find distance from player
		tempDistance = distanceFromPlayer = PlayerDistance(playerTransform.position);
		if(tempDistance > maxCoolingDistance) {
			tempDistance = maxCoolingDistance;
		}
		
		if (movingToEnd == false) {
			
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
			if(charState == CharacterState.Walking && temperature > 2) {
				velocity = .7f * maxVelocity * temperature / maxTemp + .3f * maxVelocity;
			}
			else {
				velocity = 0;	
			}
			
			agent.speed = velocity;
			
			if(PlayerDistance(agent.destination) <= .05 && charState != CharacterState.Sniffing) {
				sniffCooldown = 0;	
			}
			
			//Manage Sniffing
			if(sniffCooldown <= 0) {
				if(charState != CharacterState.Sniffing) {
					charState = CharacterState.Sniffing;
				}
				else {
					sniffCooldown -= Time.deltaTime;
					if(sniffCooldown <= -5) {
						charState = CharacterState.Walking;
						sniffCooldown = UnityEngine.Random.Range(-10f,10f) + 10 + 15 * (temperature / maxTemp);
						
						Vector3 newLocation = new Vector3(UnityEngine.Random.Range(180f,725f),100,UnityEngine.Random.Range(213f,840f));
						agent.SetDestination(newLocation);
						
					}
				}
			}
			
			
			if(temperature > 2) {
				sniffCooldown -= Time.deltaTime;
			}
			
			if(temperature == 100f) {
				movingToEnd = true;
				Vector3 newLocation = new Vector3(125f,1f,245f);
				agent.SetDestination (newLocation);
			}
		}
		else {
			
		}
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
	
	public float GetSpeed () {
		return velocity;	
	}
	
	public bool GetSniffing () {
		return charState == CharacterState.Sniffing;	
	}
	
	public bool GetStartedFloating () {
		return charState == CharacterState.Floating;	
	}
	
	public bool GetGameOver () {
		return gameOver;	
	}
	
	public bool getFrozen () {
		return temperature == 0;	
	}
}
