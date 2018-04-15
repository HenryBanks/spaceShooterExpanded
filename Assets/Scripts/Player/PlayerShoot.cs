﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public float reloadTime=0.5f;
	private float timeToNextShot = 0.0f;
	public GameObject shotPrefab;
	public Transform shotFirePoint;
	public Transform[] multipleShotFirePoints;
	public float shotSpeed=50f;
	public bool doubleShoot = false;

	public static PlayerShoot instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale > Mathf.Epsilon) {
			if (Input.GetKey (KeyCode.Space) && Time.time > timeToNextShot) {
				if (doubleShoot) {
					doubleFire ();
				} else {
					Fire ();
				}
			}
		}
		
	}

	void Fire(){
		Debug.Log ("Fire");
		timeToNextShot = Time.time + reloadTime;
		var shot=Instantiate (shotPrefab, shotFirePoint.position,transform.rotation);
		shot.GetComponent<Rigidbody2D> ().velocity = transform.up * shotSpeed;
		GetComponent<PlayerAudio> ().playSound (PlayerSounds.Fire);
		//AudioManager.instance.playSound (SoundName.Fire);
	}

	void doubleFire(){
		Debug.Log ("Double Fire");
		timeToNextShot = Time.time + reloadTime;
		for (int ii = 0; ii < multipleShotFirePoints.Length; ii++) {
			var shot = Instantiate (shotPrefab, multipleShotFirePoints[ii].position, transform.rotation);
			shot.GetComponent<Rigidbody2D> ().velocity = transform.up * shotSpeed;
		}
		GetComponent<PlayerAudio>().playSound(PlayerSounds.Fire);

		//AudioManager.instance.playSound (SoundName.Fire);
	}
}
