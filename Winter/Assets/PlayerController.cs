﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public Animator animator;
	public Component girl;
	public float accel = 0.01f;
	public float velocity = 0.0f;
	public float velMAX = 2.0f;
	public float velMIN = 0.0f;
	
	/*
	// Use this for initialization
	void Start () {
		animator.SetFloat ("velocity",wolfData.GetSpeed());
		animator.SetBool ("sniffing", false);
		animator.SetBool ("jumping", false);
		animator.SetBool ("gameOver", false);
		animator.SetBool ("frozen", true);
		animator.SetBool ("startedFloating", false);
	
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetFloat ("velocity",wolfData.GetSpeed());
		animator.SetBool ("sniffing", wolfData.GetSniffing());
		animator.SetBool ("jumping", false);
		animator.SetBool ("frozen", wolfData.getFrozen());
		animator.SetBool ("gameOver", wolfData.GetStartedFloating());
	}
	*/
}
