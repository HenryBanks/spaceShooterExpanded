﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Destroy (gameObject);
	}

	void OnBecameInvisible() {
		Debug.Log ("Became Invisible");
		//Destroy (gameObject);
	}
}
