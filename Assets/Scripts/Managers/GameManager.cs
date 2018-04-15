using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

	public static GameManager instance;
	[SerializeField]
	Explosion expPrefab;

	[SerializeField]
	CanvasGroup blackScreen;

	// Use this for initialization
	void Awake () {
		instance = this;

		blackScreen.alpha = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame() {
		StatsTracker.instance.ResetStats ();

		Vector2 playerPos = (Vector2)Player.instance.transform.position;
		Destroy (Player.instance.gameObject);

		blackScreen.alpha = 1.0f;

		Instantiate (expPrefab, playerPos, Quaternion.identity);

		StartCoroutine (WaitToRestart ());

	}

	IEnumerator WaitToRestart(){
		for (float alpha = 0.0f; alpha <= 1.0f; alpha += Time.deltaTime) {
			blackScreen.GetComponent<Image> ().color = new Color (0, 0, 0, alpha);
			yield return null;
		}

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
