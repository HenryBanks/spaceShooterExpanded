using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScore : MonoBehaviour {

	public int score;
	public Text scoreText;

	public static playerScore instance;

	// Use this for initialization
	void Start () {
		score = 0;
		setText ();
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addScore(int extraScore){
		score += extraScore;
		setText ();
	}

	void setText(){
		string scoreString = score.ToString ();
		string fullString = "SCORE: " + scoreString;
		scoreText.text = fullString;
	}
}
