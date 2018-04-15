using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

	public Text scoreText;

	public static PlayerScore instance;

	// Use this for initialization
	void Start () {
		SetText ();
		instance = this;
	}

	void SetText(){
		StatsTracker.instance.CalculateScore ();
		string scoreString = StatsTracker.instance.Score.ToString ();
		string fullString = "SCORE: " + scoreString;
		scoreText.text = fullString;
	}

	void Update(){
		SetText ();
	}
}
