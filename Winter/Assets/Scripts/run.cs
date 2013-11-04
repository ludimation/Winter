using UnityEngine;
using System.Collections;

public class run : MonoBehaviour {
	
	private NavMeshAgent agent;
	
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent>();
		agent.speed = 4;
		Vector3 movVec = new Vector3(230,0,460);
		agent.SetDestination(movVec);
		
	}
	
	void Update () {
		
	}
}
