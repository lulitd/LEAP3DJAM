﻿using UnityEngine;
using System.Collections;

public class collisionDetectPlayer : MonoBehaviour {

	private GameObject player;
	private GameObject[] Monsters;
	private teleportControl controller;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		Monsters = GameObject.FindGameObjectsWithTag ("Slime");
		controller = GameObject.FindObjectOfType<teleportControl> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Monsters = GameObject.FindGameObjectsWithTag ("Slime");

	}

	void OnCollisionEnter(Collision col){
		//Debug.Log ("collision");
		if (col.gameObject.tag == "Slime" && controller.current_Status == 0) {
			Debug.Log("Player Dies");
		}
	}

	void OnCollisionStay(Collision col){
		//Debug.Log ("collision stay");
	}
}