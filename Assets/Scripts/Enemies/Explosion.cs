using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
	
	[SerializeField]
	float explosionRadius=2.2f;

	[SerializeField]
	float explosionForce=100f;

	// Use this for initialization
	void Awake () {
		Explode ();
		Destroy (gameObject, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Explode(){


		Vector2 explosionPos = (Vector2)transform.position;

		Collider2D[] colliders = Physics2D.OverlapCircleAll (explosionPos, explosionRadius);
		foreach (Collider2D hit in colliders) {
			Rigidbody2D expRb = hit.GetComponent<Rigidbody2D> ();

			if (expRb != null) {
				float distance = Vector2.Distance (explosionPos, (Vector2)expRb.transform.position);
				Vector2 force=explosionForce*((Vector2)expRb.transform.position - explosionPos).normalized/(Mathf.Pow(distance+1,2.0f));
				expRb.AddForce (force, ForceMode2D.Impulse);
				int damage=(int)force.magnitude;
				if (hit.GetComponent<Destructible> () != null) {
					hit.GetComponent<Destructible> ().TakeDamage (damage);
				} else if (hit.GetComponent<PlayerDamage> () != null) {
					hit.GetComponent<PlayerDamage> ().TakeDamage (damage);
				}
			}
		}
	}
}
