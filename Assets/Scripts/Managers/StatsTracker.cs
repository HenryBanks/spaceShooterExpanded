using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTracker : MonoBehaviour {

	public static StatsTracker instance;

	int enemiesDestroyed=0;
	public int EnemiesDestroyed{get{return enemiesDestroyed; }}
	int meteorsDestroyed=0;
	public int MeteorsDestroyed{get{return meteorsDestroyed; }}
	int hullRepairs=0;
	public int HullRepairs{get{return hullRepairs; }}
	float timeTaken=0.0f;
	public float TimeTaken{get{ return timeTaken; }}
	int score=0;
	public int Score{get{ return score; }}

	float timeAtStart;



	public void EnemyDestroyed(){
		enemiesDestroyed++;
	}

	public void MeteorDestroyed(){
		meteorsDestroyed++;
	}

	public void HullRepaired(){
		hullRepairs++;
	}

	void SetTimeTaken(){
		timeTaken = Time.time - timeAtStart;
	}

	public void CalculateScore(){
		SetTimeTaken ();

		score = 10000 + (200 * enemiesDestroyed) + (100 * meteorsDestroyed) - (500 * hullRepairs) - (int)(100 * timeTaken);
	}

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
		} else if(instance!=this){
			Destroy (gameObject);
		}
		timeAtStart = Time.time;
	}

	public void ResetStats(){
		enemiesDestroyed = 0;
		meteorsDestroyed = 0;
		hullRepairs = 0;
		timeTaken = 0.0f;
		timeAtStart = Time.time;
	}

}
