using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float engineForce=1f;
	//public float reverseForce=1f;
	public float maxSpeed=5f;
	public float boostMultiplier=2f;
	public float rotateSpeed=2f;
	private Rigidbody2D rb;
	public SpriteRenderer engineRend;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		engineRend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		var relativeVelocity = transform.InverseTransformDirection (rb.velocity);
		//Debug.Log (relativeVelocity);

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			engineForce *= boostMultiplier;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			engineForce /= boostMultiplier;
		}

		if (Input.GetAxis ("Vertical") > 0 && relativeVelocity.y < maxSpeed) {
			rb.AddForce (transform.up * Input.GetAxis ("Vertical") * engineForce);
			engineRend.enabled = true;
		} else {
			engineRend.enabled = false;
		}
		transform.Rotate (Vector3.back, Input.GetAxis ("Horizontal") * rotateSpeed);
	}


}
