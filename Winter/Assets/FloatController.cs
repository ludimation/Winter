﻿using UnityEngine;
using System.Collections;

public class FloatController : MonoBehaviour {
	
	public GameObject dead_kid; // it's not that morbid
	public GameObject dead_kid2; // The actual dead kid on the ground, not the ghost.
	public GameObject dead_wolf;	// ok its pretty morbid.
	public ThirdPersonController tpc;
	
	public GameObject main_camera;
	public GameObject camera_controller;
	
	
	private bool floating;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (floating) {
			dead_kid.transform.position += Vector3.up * Time.deltaTime * 3.0f;
			dead_wolf.transform.position += Vector3.up * Time.deltaTime * 3.0f;
		}
	}
	
	void OnTriggerEnter(Collider col) {
		floating = true;
		tpc.gravity = 0.0f;
		
		// Disable mouse Controls
		//MouseOrbit mo = camera_controller.GetComponent<MouseOrbit>();
		//mo.enabled = false;
		
		main_camera.GetComponent<MouseOrbit>().enabled = false;
		Debug.Log("Camera disabled.");
		
		camera_controller.transform.LookAt(dead_kid2.transform);
	}
}
