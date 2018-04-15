using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Objective : MonoBehaviour {

	public static Objective instance;

	[SerializeField]
	Image blackScreen;

	void Awake(){
		instance = this;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("player")) {

			StartCoroutine (EndFunction ());

		}
	}

	IEnumerator EndFunction(){
		DialogueManager.instance.LoadDialogue (DialogueName.End);
		//This is super hacky, so here's an explanation of why this works (and a reminder to maybe change it to something better)
		//The yield will wait for 0.01 s of game time, but while the dialogue window is active, game time doesn't change.
		//As soon as you close the dialogue, game time will progress and the EndScene will load

		yield return new WaitForSeconds (0.01f);

		Time.timeScale = 0.0f;

		for (float alpha = 0.0f; alpha <= 1.0f; alpha += Time.fixedUnscaledDeltaTime*2f) {
			blackScreen.color = new Color (0, 0, 0, alpha);
			yield return null;
		}
			
		//yield return new WaitForSeconds (0.01f);

		SceneManager.LoadScene ("EndScene");
	}


	void Update(){
		if (Player.instance != null) {
			ObjectivePointer.instance.UpdatePointer (transform.position);

			float distance = Vector3.Distance (transform.position, Player.instance.transform.position);

			if (distance < 100.0f) {
				SpawnManager.instance.setDifficulty (Difficulty.Hard);
			} else if (distance < 200.0f) {
				SpawnManager.instance.setDifficulty (Difficulty.Medium);
			} else if (distance < 600.0f) {
				SpawnManager.instance.setDifficulty (Difficulty.Medium);
			}
		}
	}

}
