using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

	[SerializeField]
	Sprite[] damageSprites;
	SpriteRenderer damageRend;
	SpriteRenderer shieldRend;

	public float invincibilityTime=0.5f;
	//private float timeToNextColl = 0.0f;
	private bool isShielded = false;

	public float overShieldRechargeTime=8.0f;
	public float overShieldDuration=2.0f;
	float timeToOverShieldRecharge=0.0f;
	float timeToOverShieldEnd=0.0f;

	int hull;
	[SerializeField]
	int maxHull=100;

	int shield;
	[SerializeField]
	int maxShield=100;
	float shieldDelay=1f;
	int shieldRegenRate=1;
	float timeToStartRegen=0.0f;

	public Text shieldText;

	public static PlayerDamage instance;

	// Use this for initialization
	void Awake () {
		instance = this;
		damageRend=transform.Find ("DamagePoint").GetComponent<SpriteRenderer> ();
		shieldRend=transform.Find ("ShieldPoint").GetComponent<SpriteRenderer> ();
		shieldRend.enabled = false;
		isShielded = false;
		hull = maxHull;
		shield = maxShield;
		//InvokeRepeating ("updateShieldText",1.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E)&&Time.time>timeToOverShieldRecharge) {
			//StartCoroutine ("shieldOn");
			//shieldOn ();
			ShieldOn();
			timeToOverShieldEnd=Time.time+overShieldDuration;
			timeToOverShieldRecharge=Time.time+overShieldRechargeTime+overShieldDuration;
		}

		if (isShielded && Time.time > timeToOverShieldEnd) {
			ShieldOff ();
		}

		if (Time.time < timeToOverShieldRecharge) {
			if (isShielded) {
				DrainOverShield ();
			} else {
				RechargeOverShield ();
			}
		}


	}

	void FixedUpdate(){
		if (Time.time>timeToStartRegen) {
			shield = (int)Mathf.Min (shield + shieldRegenRate, maxShield);
			ShieldChanged ();
		}

	}

	void RechargeOverShield(){
		StatusManager.instance.UpdateOverShield (1.0f-((timeToOverShieldRecharge - Time.time)/overShieldRechargeTime));
	}

	void DrainOverShield(){
		StatusManager.instance.UpdateOverShield ((timeToOverShieldEnd -Time.time)/overShieldDuration);
	}

	void RepairHull(){
		hull = maxHull;
		HullChanged ();
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("pickUp")){
			RepairHull ();
			Destroy (coll.gameObject);
			StatsTracker.instance.HullRepaired ();
		}
	}

	public void TakeDamage(int damage){
		if (!isShielded) {
			timeToStartRegen = Time.time + shieldDelay;
			if (shield > 0) {
				shield -= damage;
				ShieldChanged ();
			} else {
				hull -= damage;
				HullChanged ();
			}
		}
	}

	void ShieldChanged(){
		if (StatusManager.instance != null) {
			StatusManager.instance.UpdateShield ((float)shield / maxShield);
		}
	}

	void HullChanged(){
		StatusManager.instance.UpdateHull ((float)hull/maxHull);
		if (hull <= 0) {
			GameManager.instance.RestartGame ();
			//Destroy (gameObject);
		} else if (0 < hull && hull < maxHull) {
			int damageLevel = 2 - (3 * hull / maxHull);
			damageRend.sprite = damageSprites [damageLevel];
		} else if (hull == maxHull) {
			damageRend.sprite = null;
		}
	}

	void ShieldOn(){
		isShielded = true;
		shieldRend.enabled = true;
		GetComponent<PlayerAudio> ().playSound (PlayerSounds.ShieldUp);
		//AudioManager.instance.playSound (SoundName.ShieldUp);
	}

	void ShieldOff(){
		GetComponent<PlayerAudio> ().playSound (PlayerSounds.ShieldDown);
		//AudioManager.instance.playSound (SoundName.ShieldDown);
		isShielded = false;
		shieldRend.enabled = false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log ("relative velocity: "+coll.relativeVelocity.ToString());
		TakeDamage ((int)(coll.relativeVelocity.magnitude*10*coll.gameObject.GetComponent<Rigidbody2D>().mass));
	}

	//	IEnumerator shieldOn(){
	//		isShielded = true;
	//		shieldRend.enabled = true;
	//		AudioManager.instance.playSound (SoundName.ShieldUp);
	//
	//
	//		yield return new WaitForSeconds(overShieldDuration);
	//
	//		AudioManager.instance.playSound (SoundName.ShieldDown);
	//		isShielded = false;
	//		shieldRend.enabled = false;
	//	}

}
