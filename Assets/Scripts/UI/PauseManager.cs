using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

	CanvasGroup pauseMenu;

	bool isPaused=false;

	void Awake(){
		pauseMenu = GetComponent<CanvasGroup> ();
		pauseMenu.alpha = 0.0f;
		pauseMenu.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.P)) {
			isPaused = !isPaused;

			if (isPaused) {
				Time.timeScale = 0;
				PlayerShoot.instance.enabled = false;
				PlayerMovement.instance.enabled = false;
				pauseMenu.interactable = true;
				pauseMenu.alpha = 1.0f;

			} else {
				Time.timeScale = 1;
				PlayerShoot.instance.enabled = true;
				PlayerMovement.instance.enabled = true;
				pauseMenu.interactable = false;
				pauseMenu.alpha = 0.0f;

			}
		}
		
	}
}
