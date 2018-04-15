using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale > Mathf.Epsilon) {
			transform.up = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		}
	}
}
