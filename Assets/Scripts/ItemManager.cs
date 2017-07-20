using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
	public GameObject meteorPrefab;
	public GameObject healPrefab;
	public int HorizontalTiles = 25;
	public int VerticalTiles=25;
	public int Key=1;
	public Transform Player;
	public float nearestSpawn=10f;
	public float MaxDistanceFromCenter=4f;
	public float deleteDistance=15f;

	public List<GameObject> itemList;
	private List<GameObject> itemsToDelete;

	public static ItemManager instance;

	public int RandomIntGen(int x, int y){
		return RandomHelper.Range(x, y, Key, 100);
	}

	void deleteMeteors(){
		itemsToDelete = new List<GameObject> ();

		foreach (GameObject tempMeteor in itemList){
			if (tempMeteor == null) {
				continue;
			}
			//Debug.Log(Vector3.Distance (transform.position, tempMeteor.transform.position));
			if (deleteDistance < Vector3.Distance (transform.position, tempMeteor.transform.position)) {
				Debug.Log ("Registered to Delete");
				itemsToDelete.Add (tempMeteor);
			}
		}
		foreach (GameObject tempMeteor in itemsToDelete) {
			itemList.Remove (tempMeteor);
			Destroy (tempMeteor);
		}
	}

	public void RandomItemGen(int x, int y){
		Vector3 meteorPos = new Vector3 (x + (int)transform.position.x, y + (int)transform.position.y, 0.0f) + new Vector3 ( - HorizontalTiles / 2, - VerticalTiles / 2, 0);
		if (RandomHelper.Range (x, y, Key, 100)>94) {
			GameObject newItem=Instantiate (meteorPrefab, meteorPos, Quaternion.Euler(0.0f,0.0f,Random.Range(0.0f,360.0f)));
			itemList.Add (newItem);
		}
		else if (RandomHelper.Range (x, y, Key, 100)==94) {
			GameObject newItem=Instantiate (healPrefab, meteorPos, Quaternion.Euler(0.0f,0.0f,Random.Range(0.0f,360.0f)));
			itemList.Add (newItem);
		}
	}

	private bool isSpaceClear(Vector3 tileSpace){
		foreach (GameObject tempItem in itemList){
			if (tempItem == null) {
				continue;
			}
			if (tempItem.transform.position==tileSpace) {
				return false;
			}
		}
		return true;
	}



	public void generateItems(){
		
		var offset = new Vector3 ( - HorizontalTiles / 2, - VerticalTiles / 2, 0);
		transform.position = new Vector3((int)Player.position.x,(int)Player.position.y,Player.position.z);
		StartCoroutine ("deleteMeteors");
		//deleteMeteors ();
		for (int x = 0; x < HorizontalTiles; x++) {
			for (int y = 0; y < VerticalTiles; y++) {
				Vector3 itemPos = new Vector3 (x + (int)transform.position.x, y + (int)transform.position.y, 0.0f) + offset;
				if (nearestSpawn < Vector3.Distance (transform.position, itemPos)) {
					if (isSpaceClear (itemPos)) {
						//Debug.Log (transform.position);

						if (RandomIntGen (x + (int)transform.position.x, y + (int)transform.position.y) > 94) {
							GameObject newMeteor = Instantiate (meteorPrefab, itemPos, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
							itemList.Add (newMeteor);
						} else if (RandomIntGen (x + (int)transform.position.x, y + (int)transform.position.y) == 94) {
							GameObject newHeal = Instantiate (healPrefab, itemPos, Quaternion.Euler (0.0f, 0.0f, Random.Range (0.0f, 360.0f)));
							itemList.Add (newHeal);
						}

						//RandomItemGen (x + (int)transform.position.x, y + (int)transform.position.y);

					}
				}

			}
		}
	}


	void Start () {
		instance = this;
		itemList = new List<GameObject> ();
		generateItems ();
	}
	

}
