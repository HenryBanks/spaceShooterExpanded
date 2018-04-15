using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	[SerializeField]
	float reloadTime=0.5f;
	private float timeToNextShot = 0.0f;

	[SerializeField]
	GameObject shotPrefab;
	Transform shotFirePoint;
	[SerializeField]
	float shotSpeed=50f;
	[SerializeField]
	AudioClip shotSound;


	// Use this for initialization
	void Awake () {
		shotFirePoint = transform.Find ("shotFirePoint");
	}
	
	void Update () {
		if (Player.instance != null) {
			transform.up = Player.instance.transform.position - transform.position;
			float distance = Vector3.Distance (Player.instance.transform.position, transform.position);
			if (Time.time > timeToNextShot && distance <= 6f) {
				Debug.Log ("EnemyFire");
				timeToNextShot = Time.time + reloadTime;
				var shot = Instantiate (shotPrefab, shotFirePoint.position, transform.rotation);
				shot.GetComponent<Rigidbody2D> ().velocity = transform.up * shotSpeed;

				GetComponent<AudioSource> ().PlayOneShot (shotSound);
			}
		}
	}
}
