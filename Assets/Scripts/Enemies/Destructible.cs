using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	protected int health;
	[SerializeField]
	protected int maxHealth=100;
	[SerializeField]
	AudioClip crashSound;
	AudioSource audioSource;

	// Use this for initialization
	void Awake () {
		health = maxHealth;
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void TakeDamage(int damage){
		health -= damage;
		if (health <= 0) {
			ItemManager.instance.itemList.Remove (gameObject);
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (!coll.gameObject.CompareTag ("projectile")) {
			int damage = (int)(coll.relativeVelocity.magnitude * 10 * coll.gameObject.GetComponent<Rigidbody2D> ().mass);
			audioSource.volume = 0.25f * damage / 100.0f;
			audioSource.PlayOneShot (crashSound);
			audioSource.volume = 0.25f;
			TakeDamage (damage);
		}
	}


}
