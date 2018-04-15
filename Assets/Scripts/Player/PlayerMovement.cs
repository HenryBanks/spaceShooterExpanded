using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float engineForce=1f;
	//public float reverseForce=1f;
	public float maxSpeed=8f;
	//public float boostMultiplier=2f;
	public float rotateSpeed=2f;
	private Rigidbody2D rb;
	public SpriteRenderer engineRend;

	public static PlayerMovement instance;

	// Use this for initialization
	void Start () {
		instance = this;
		rb = GetComponent<Rigidbody2D> ();
		engineRend.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var relativeVelocity = transform.InverseTransformDirection (rb.velocity);
		//Debug.Log (relativeVelocity);

//		if (Input.GetKeyDown (KeyCode.LeftShift)) {
//			engineForce *= boostMultiplier;
//		}
//		if (Input.GetKeyUp (KeyCode.LeftShift)) {
//			engineForce /= boostMultiplier;
//		}

		if (Input.GetAxis ("Vertical") > 0 && relativeVelocity.y < maxSpeed) {
			rb.AddForce (transform.up * Input.GetAxis ("Vertical") * engineForce);
			engineRend.enabled = true;
		} else {
			engineRend.enabled = false;
		}
		rb.angularVelocity = -Input.GetAxis ("Horizontal") * rotateSpeed;

		if (Input.GetAxis ("Vertical") < 0 && relativeVelocity.y > -maxSpeed) {
			rb.AddForce (transform.up * Input.GetAxis ("Vertical") * engineForce*0.7f);
		}

	}


}
