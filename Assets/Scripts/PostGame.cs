using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostGame : MonoBehaviour {

	[SerializeField]
	Text resultsText;
	[SerializeField]
	Text headingText;

	void Start(){
		Time.timeScale = 1.0f;
		GenerateText ();
		GenerateHeading ();
	}

	public void RestartGame(){
		StatsTracker.instance.ResetStats ();
		SceneManager.LoadScene ("GameScene");
	}

	void GenerateHeading(){

	}

	void GenerateText(){
		string resultsString=10000.ToString()+"\n";
		resultsString+=StatsTracker.instance.EnemiesDestroyed.ToString()+"\n";
		resultsString+=StatsTracker.instance.MeteorsDestroyed.ToString()+"\n";
		resultsString+=StatsTracker.instance.HullRepairs.ToString()+"\n";
		resultsString+=StatsTracker.instance.TimeTaken.ToString("F2")+"s\n";
		resultsString+=StatsTracker.instance.Score.ToString();

		resultsText.text = resultsString;

	}

}
