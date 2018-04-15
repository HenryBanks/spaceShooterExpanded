using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour {

	public static Upgrades instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void upgradeShieldLength(){
		Debug.Log ("shield length upgraded");
		PlayerDamage.instance.overShieldDuration *= 1.2f;
	}

	public void upgradeShieldRecharge(){
		Debug.Log ("shield recharge upgraded");
		PlayerDamage.instance.overShieldRechargeTime *= 0.8f;
	}

	public void upgradeShotRate(){
		Debug.Log ("shot reload upgraded");
		PlayerShoot.instance.reloadTime *= 0.8f;
	}

	public void upgradeToDoubleShot(){
		Debug.Log ("double shot upgraded");
		PlayerShoot.instance.doubleShoot = true;
	}

	public void upgradeEngineForce(){
		Debug.Log ("engine force upgraded");
		PlayerMovement.instance.engineForce *= 1.5f;
	}

	public void upgradeTurningSpeed(){
		Debug.Log ("turning speed upgraded");
		PlayerMovement.instance.rotateSpeed *= 1.2f;
	}

}
