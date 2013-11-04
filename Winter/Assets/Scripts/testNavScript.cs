using UnityEngine;
using System.Collections;

public class testNavScript : MonoBehaviour {
	public NavMeshAgent agent;
	
	// Use this for initialization
	void Start () {
		agent.destination = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = transform.position;
	}
}
