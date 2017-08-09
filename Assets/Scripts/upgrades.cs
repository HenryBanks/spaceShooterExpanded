using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgrades : MonoBehaviour {

	public static upgrades instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void upgradeShieldLength(){
		Debug.Log ("shield length upgraded");
		playerDamage.instance.shieldDuration *= 1.2f;
	}

	public void upgradeShieldRecharge(){
		Debug.Log ("shield recharge upgraded");
		playerDamage.instance.shieldRechargeTime *= 0.8f;
	}

	public void upgradeShotRate(){
		Debug.Log ("shot reload upgraded");
		playerShoot.instance.reloadTime *= 0.8f;
	}
}
