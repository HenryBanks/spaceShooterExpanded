using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveIntro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0.0f, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
