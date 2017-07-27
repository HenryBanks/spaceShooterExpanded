using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public GameObject player;
	public float reloadTime=0.5f;
	private float timeToNextShot = 0.0f;
	public GameObject shotPrefab;
	public Transform shotFirePoint;
	public float shotSpeed=50f;
	public AudioSource shotSound;


	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("player");
	}
	
	void Update () {
		transform.up = player.transform.position - transform.position;
		float distance = Vector3.Distance (player.transform.position, transform.position);
		if (Time.time > timeToNextShot && distance<=6f) {
			Debug.Log ("EnemyFire");
			timeToNextShot = Time.time + reloadTime;
			var shot=Instantiate (shotPrefab, shotFirePoint.position,transform.rotation);
			shot.GetComponent<Rigidbody2D> ().velocity = transform.up * shotSpeed;
			shotSound.Play ();
		}

	}
}
