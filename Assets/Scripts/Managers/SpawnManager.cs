using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public static SpawnManager instance;

	float spawnEventRate=20.0f;
	float spawnEnemyRate=3.0f;

	float spawnMissileRate=1.5f;

	float spawnMeteorRate=0.5f;
	float meteorSpeed=10.0f;

	float nextSpawnTime=0.0f;
	float spawnDistance=15.0f;
	float spawnSpeed=2.0f;

	[SerializeField]
	SpawnGroup[] easySpawnGroups;

	[SerializeField]
	SpawnGroup[] mediumSpawnGroups;

	[SerializeField]
	SpawnGroup[] hardSpawnGroups;

	SpawnGroup[] spawnGroups;
	SpawnGroup currentGroup;

	void Awake(){
		instance = this;
		spawnGroups = easySpawnGroups;
	}

	public void setDifficulty(Difficulty dif){
		switch (dif) {
		case Difficulty.Easy:
			spawnGroups = easySpawnGroups;
			break;
		case Difficulty.Medium:
			spawnGroups = mediumSpawnGroups;
			break;
		case Difficulty.Hard:
			spawnGroups = hardSpawnGroups;
			break;
		}
	}

	void Update(){
		if (Player.instance != null) {
			if (Time.time > nextSpawnTime) {
				nextSpawnTime = Time.time + spawnEventRate;
				currentGroup = spawnGroups [Random.Range (0, spawnGroups.Length)];
				switch (currentGroup.GroupType) {
				case SpawnType.Enemy:
					StartCoroutine (SpawnEnemies ());
					break;
				case SpawnType.Meteor:
				//SpawnMeteors2 ();
					StartCoroutine (SpawnMeteors ());
					break;
				case SpawnType.Missile:
					StartCoroutine (SpawnMissiles ());
					break;
				}
			}
		}
	}

	private IEnumerator SpawnMissiles(){
		//Cycle through enemies to spawn and instantiate them
		for (int i = 0; i < currentGroup.Destructibles.Length; i++) {

			yield return new WaitForSeconds (spawnMissileRate);

			if (Player.instance != null) {

				Vector2 playerPos = Player.instance.gameObject.transform.position;

				Destructible d = currentGroup.Destructibles [i];
				float randomAngle = Random.Range (0.0f, 2 * Mathf.PI);
				Vector2 spawnPos = playerPos + new Vector2 (spawnDistance * Mathf.Cos (randomAngle), spawnDistance * Mathf.Sin (randomAngle));
				Instantiate (d, spawnPos, Quaternion.identity);
			}
		}
	}

	private IEnumerator SpawnEnemies(){
		//Cycle through enemies to spawn and instantiate them
		for (int i = 0; i < currentGroup.Destructibles.Length; i++) {
			
			yield return new WaitForSeconds (spawnEnemyRate);

			if (Player.instance != null) {

				Vector2 playerPos = Player.instance.gameObject.transform.position;

				Destructible d = currentGroup.Destructibles [i];
				float randomAngle = Random.Range (0.0f, 2 * Mathf.PI);
				Vector2 spawnPos = playerPos + new Vector2 (spawnDistance * Mathf.Cos (randomAngle), spawnDistance * Mathf.Sin (randomAngle));
				Instantiate (d, spawnPos, Quaternion.identity);
				randomAngle = Random.Range (0.0f, 2 * Mathf.PI);

				d.GetComponent<Rigidbody2D> ().velocity = new Vector2 (spawnSpeed * Mathf.Cos (randomAngle), spawnSpeed * Mathf.Sin (randomAngle));
			}
		}
	}

	private IEnumerator SpawnMeteors(){
		
		float angleFromPlayer = Random.Range (0.0f, 2 * Mathf.PI);
		Vector2 spawnOffset = new Vector2 (spawnDistance * Mathf.Cos (angleFromPlayer), spawnDistance * Mathf.Sin (angleFromPlayer));
		//Cycle through enemies to spawn and instantiate them
		for (int i = 0; i < currentGroup.Destructibles.Length; i++) {

			yield return new WaitForSeconds (spawnMeteorRate);

			if (Player.instance != null) {
				Vector2 playerPos = Player.instance.gameObject.transform.position;
				Vector2 randomOffset = new Vector2 (Random.Range (-6, 6), Random.Range (-6, 6));
				var d = Instantiate (currentGroup.Destructibles [i], playerPos + spawnOffset + randomOffset, Quaternion.identity);

				d.transform.Rotate (0.0f, 0.0f, Random.Range (0.0f, 360.0f));

				Vector2 direction = new Vector2 (-Mathf.Cos (angleFromPlayer), -Mathf.Sin (angleFromPlayer));

				d.GetComponent<Rigidbody2D> ().velocity = meteorSpeed * direction;

			}

		}
	}
		
}

public enum Difficulty{
	Easy,
	Medium,
	Hard,
}
