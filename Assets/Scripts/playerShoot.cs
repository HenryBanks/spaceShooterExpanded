using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour {

	public float reloadTime=0.5f;
	private float timeToNextShot = 0.0f;
	public GameObject shotPrefab;
	public Transform shotFirePoint;
	public float shotSpeed=50f;
	public AudioSource shotSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey(KeyCode.Space) && Time.time > timeToNextShot) {
			Debug.Log ("Fire");
			timeToNextShot = Time.time + reloadTime;
			var shot=Instantiate (shotPrefab, shotFirePoint.position,transform.rotation);
			shot.GetComponent<Rigidbody2D> ().velocity = transform.up * shotSpeed;
			shotSound.Play ();
		}
		
	}
}
