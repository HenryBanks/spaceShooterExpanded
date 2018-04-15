using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour {

	public static StatusManager instance;

	Image shieldBar;
	Image hullBar;
	Image overShieldBar;

	void Awake(){
		instance = this;
		shieldBar = transform.Find ("Shield").Find ("Bar").GetComponent<Image> ();
		hullBar = transform.Find ("Hull").Find ("Bar").GetComponent<Image> ();
		overShieldBar = transform.Find ("OverShield").Find ("Bar").GetComponent<Image> ();
	}

	public void UpdateShield(float percentage){
		shieldBar.fillAmount = percentage;
	}

	public void UpdateHull(float percentage){
		hullBar.fillAmount = percentage;
	}

	public void UpdateOverShield(float percentage){
		overShieldBar.fillAmount = percentage;
	}

}
