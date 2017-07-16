using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShot : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 3f);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("hit");
		Destroy (gameObject);
	}

	// Update is called once per frame
	void FixedUpdate () {
	}

	void Update(){
	}
}
