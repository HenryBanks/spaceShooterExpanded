using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public float engineForce=1f;
	//public float reverseForce=1f;
	public float maxSpeed=5f;
	public float boostSpeed;
	public float rotateSpeed=2f;
	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		var relativeVelocity = transform.InverseTransformDirection (rb.velocity);
		//Debug.Log (relativeVelocity);
		if (Input.GetAxis ("Vertical") > 0 && relativeVelocity.y<maxSpeed) {
			rb.AddForce (transform.up * Input.GetAxis ("Vertical") * engineForce);
		}
		transform.Rotate (Vector3.back, Input.GetAxis ("Horizontal") * rotateSpeed);
	}


}
