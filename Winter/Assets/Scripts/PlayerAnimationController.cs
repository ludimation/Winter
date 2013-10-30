using UnityEngine;
using System.Collections;

public class PlayerAnimationController : MonoBehaviour {
	
	private Animator animator;
	public float accel = 0.01f;
	public float velocity = 0.0f;
	public float velMAX = 2.0f;
	public float velMIN = 0.0f;

	// Use this for initialization
	void Start () {
		
		animator = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.W) && velocity < velMAX)
		{
			velocity = velocity + accel;
			animator.SetFloat("velocity", velocity);
		}
		
		if (Input.GetKeyUp(KeyCode.W) && velocity > velMIN)
		{
			velocity = velocity - accel;
			animator.SetFloat("velocity", velocity);
		}	
		
		if (Input.GetKeyDown(KeyCode.Space))
		{
			animator.SetBool("jumping", true);
		}
		
		if (Input.GetKeyUp(KeyCode.Space))
		{
			animator.SetBool("jumping", false);
		}
	}
}
