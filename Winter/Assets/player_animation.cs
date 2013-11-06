using UnityEngine;
using System.Collections;

public class player_animation : MonoBehaviour {
	
	private float velocity = 0;
	
	// Use this for initialization
	void Start () {
		
		velocity = 1;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		print ("Hello");
		//Component worker = gameObject.GetComponent("construction_worker");
		//print(worker.moveSpeed);
	}
}
