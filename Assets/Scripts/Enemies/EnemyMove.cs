using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	Rigidbody2D rb2d;

	[SerializeField]
	float moveForce=10f;
	[SerializeField]
	float offset=3f;
	[SerializeField]
	float maxSpeed=4f;
	[SerializeField]
	float avoidRadius=4f;
	[SerializeField]
	float forceMultiplier=20f;

	Vector2 totalForce;

	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.instance != null) {
			totalForce = new Vector2 (0.0f, 0.0f);
			AvoidObstacles ();
			MoveTowardsPlayer ();
		}
	}

	void FixedUpdate(){
		rb2d.AddForce (totalForce);
		if (rb2d.velocity.magnitude > maxSpeed) {
			rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
		}
	}

	Vector2 GetTargetPos(){
		Vector2 playerPos = (Vector2)Player.instance.transform.position;
		Vector2 targetPos = playerPos + ((Vector2)transform.position - playerPos).normalized * offset;
		return targetPos;
	}

	void MoveTowardsPlayer(){
		//rb2d.velocity = (GetTargetPos() - (Vector2)transform.position).normalized * speed;
		totalForce+=(GetTargetPos () - (Vector2)transform.position).normalized * moveForce;
//		rb2d.AddForce ((GetTargetPos () - (Vector2)transform.position).normalized * moveForce);
//		if (rb2d.velocity.magnitude > maxSpeed) {
//			rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
//		}
		//Debug.Log (rb2d.velocity);
	}

	void AvoidObstacles(){
		Vector2 pos = (Vector2)transform.position;

		Collider2D[] colliders = Physics2D.OverlapCircleAll (pos, avoidRadius);
		foreach (Collider2D obstacle in colliders) {
			Vector2 obstaclePos = (Vector2)obstacle.transform.position;
			float distance = Vector2.Distance (pos, obstaclePos);
			Vector2 force = forceMultiplier * (pos - obstaclePos).normalized / (Mathf.Pow (1 + distance, 2));
			totalForce += force;
			//rb2d.AddForce (force);
		}
	}
}
