using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

	public float reloadTime=0.5f;
	private float timeToNextShot = 0.0f;
	public GameObject shotPrefab;
	public float shotSpeed=50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeScale > Mathf.Epsilon) {
			if (Input.GetKey (KeyCode.Mouse0) && Time.time > timeToNextShot) {
				Fire ();
			}
		}
		
	}

	void Fire(){
		//Debug.Log ("Fire");
		timeToNextShot = Time.time + reloadTime;
		var shot=Instantiate (shotPrefab, transform.position+transform.up,transform.rotation);
		shot.GetComponent<Rigidbody2D> ().velocity = transform.up * shotSpeed;
		//AudioManager.instance.playSound (SoundName.Fire);
		Player.instance.GetComponent<PlayerAudio>().playSound(PlayerSounds.Fire);
	}

}
