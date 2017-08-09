using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseManager : MonoBehaviour {

	bool isPaused=false;

	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P)) {
			isPaused = !isPaused;

			if (isPaused) {
				Time.timeScale = 0;
				playerShoot.instance.enabled = false;
				playerMovement.instance.enabled = false;
				pauseMenu.SetActive (true);
			} else {
				Time.timeScale = 1;
				playerShoot.instance.enabled = true;
				playerMovement.instance.enabled = true;
				pauseMenu.SetActive (false);
			}
		}
		
	}
}
