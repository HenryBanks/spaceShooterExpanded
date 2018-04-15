using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
	public GameObject meteorPrefab1;
	public GameObject meteorPrefab2;
	public GameObject healPrefab;
	public GameObject enemyPrefab;
	public int HorizontalTiles = 25;
	public int VerticalTiles=25;
	public int Key=1;
	public float nearestSpawn=10f;
	public float MaxDistanceFromCenter=4f;
	public float deleteDistance=15f;

	public List<GameObject> itemList;
	private List<GameObject> itemsToDelete;

	public static ItemManager instance;

	[SerializeField]
	bool isIntro=false;

	public int RandomIntGen(int x, int y){
		return RandomHelper.Range(x, y, Key, 1000);
	}

	void deleteMeteors(){
		itemsToDelete = new List<GameObject> ();

		foreach (GameObject tempMeteor in itemList){
			if (tempMeteor == null) {
				continue;
			}
			//Debug.Log(Vector3.Distance (transform.position, tempMeteor.transform.position));
			if (deleteDistance < Vector3.Distance (transform.position, tempMeteor.transform.position)) {
				//Debug.Log ("Registered to Delete");
				itemsToDelete.Add (tempMeteor);
			}
		}
		foreach (GameObject tempMeteor in itemsToDelete) {
			itemList.Remove (tempMeteor);
			Destroy (tempMeteor);
		}
	}

	private bool isSpaceClear(Vector3 tileSpace){
		foreach (GameObject tempItem in itemList){
			if (tempItem == null) {
				continue;
			}
			if ((tempItem.transform.position-tileSpace).magnitude<1.0f) {
				return false;
			}
			if (Objective.instance != null) {
				if (Vector3.Distance (Objective.instance.transform.position, tileSpace) < 5.0f) {
					return false;
				}
			}
		}
		return true;
	}



	public void generateItems(){
		Vector2 playerPos = Player.instance.transform.position;
		var offset = new Vector3 ( - HorizontalTiles / 2, - VerticalTiles / 2, 0);
		transform.position = new Vector2((int)playerPos.x,(int)playerPos.y);
		int posX = (int)transform.position.x;
		int posY = (int)transform.position.y;
		StartCoroutine ("deleteMeteors");
		//deleteMeteors ();
		for (int x = 0; x < HorizontalTiles; x++) {
			for (int y = 0; y < VerticalTiles; y++) {
				Vector3 itemPos = new Vector3 (x + (int)transform.position.x, y + (int)transform.position.y, 0.0f) + offset;
				if (nearestSpawn < Vector3.Distance (transform.position, itemPos)) {
					if (isSpaceClear (itemPos)) {
						//Debug.Log (transform.position);

						if (RandomIntGen (x + posX, y + posY) > 970) {
							GameObject newMeteor = Instantiate (meteorPrefab1, itemPos, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
							itemList.Add (newMeteor);
						}
						else if ((RandomIntGen (x + posX, y + posY) > 940) && (RandomIntGen (x + posX, y + posY) <=970)) {
							GameObject newMeteor = Instantiate (meteorPrefab2, itemPos, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
							itemList.Add (newMeteor);
						}
						else if (RandomIntGen (x + posX, y + posY) >933 && RandomIntGen (x + posX, y + posY) <=940) {
							GameObject newEnemy = Instantiate (enemyPrefab, itemPos, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
							itemList.Add (newEnemy);
						} 
						else if (RandomIntGen (x + posX, y + posY) >930 && RandomIntGen (x + posX, y + posY) <=933) {
							GameObject newHeal = Instantiate (healPrefab, itemPos, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
							itemList.Add (newHeal);
						}

						//RandomItemGen (x + (int)transform.position.x, y + (int)transform.position.y);

					}
				}

			}
		}
	}

	public void generateItemsIntro(){
		Vector2 playerPos = Player.instance.transform.position;
		var offset = new Vector2 ( - HorizontalTiles / 2, - VerticalTiles / 2);
		transform.position = new Vector2((int)playerPos.x,(int)playerPos.y);
		int posX = (int)transform.position.x;
		int posY = (int)transform.position.y;
		StartCoroutine ("deleteMeteors");
		//deleteMeteors ();
		for (int x = 0; x < HorizontalTiles; x++) {
			for (int y = 0; y < VerticalTiles; y++) {
				Vector2 itemPos = new Vector2 (x + (int)transform.position.x, y + (int)transform.position.y) + offset;

				if (Mathf.Abs (itemPos.x) < 2.0f) {
					continue;
				}

				if (nearestSpawn < Vector2.Distance (transform.position, itemPos)) {
					if (isSpaceClear (itemPos)) {
						//Debug.Log (transform.position);

						if (RandomIntGen (x + posX, y + posY) > 970) {
							GameObject newMeteor = Instantiate (meteorPrefab1, itemPos, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
							itemList.Add (newMeteor);
						}
						else if ((RandomIntGen (x + posX, y + posY) > 940) && (RandomIntGen (x + posX, y + posY) <=970)) {
							GameObject newMeteor = Instantiate (meteorPrefab2, itemPos, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
							itemList.Add (newMeteor);
						}


					}
				}

			}
		}
	}



	void Start () {
		instance = this;
		Key = Random.Range (0, 100);
		itemList = new List<GameObject> ();
		if (isIntro) {
			generateItemsIntro ();
		} else {
			generateItems ();
		}
	}
	

}
