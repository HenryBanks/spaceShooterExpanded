using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour {

	Rigidbody2D rb;

	[SerializeField]
	float rotationRate=60f;

	[SerializeField]
	float speed=6f;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Player.instance != null) {
			Vector3 vecToPlayer = Player.instance.transform.position - transform.position;

			float angle = Vector3.SignedAngle (vecToPlayer, transform.up, Vector3.forward);

			rb.MoveRotation (rb.rotation - rotationRate * Time.deltaTime * Mathf.Sign (angle));

			rb.velocity = transform.up * speed;
		}
	}
}
