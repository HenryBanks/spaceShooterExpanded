using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

	CanvasGroup startMenu;

	[SerializeField]
	Image blackScreen;

	void Awake(){
		startMenu = GetComponent<CanvasGroup> ();
	}

	public void StartGame(){
		startMenu.alpha = 0.0f;
		StartCoroutine (WaitToStart ());
	}

	IEnumerator WaitToStart(){
		for (float alpha = 0.0f; alpha <= 1.0f; alpha += Time.deltaTime) {
			blackScreen.color = new Color (0, 0, 0, alpha);
			yield return null;
		}

		SceneManager.LoadScene("GameScene");
	}

}
