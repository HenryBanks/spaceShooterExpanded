using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour {
	public GameObject meteorPrefab;
	public int HorizontalTiles = 25;
	public int VerticalTiles=25;
	public int Key=1;
	public Transform Player;
	public float nearestSpawn=10f;
	public float MaxDistanceFromCenter=4f;
	public float deleteDistance=15f;

	public List<GameObject> meteorList;
	private List<GameObject> meteorsToDelete;

	public int RandomMeteorGen(int x, int y){
		return RandomHelper.Range(x, y, Key, 10);
	}

	void deleteMeteors(){
		meteorsToDelete = new List<GameObject> ();

		foreach (GameObject tempMeteor in meteorList){
			//Debug.Log(Vector3.Distance (transform.position, tempMeteor.transform.position));
			if (deleteDistance < Vector3.Distance (transform.position, tempMeteor.transform.position)) {
				Debug.Log ("Registered to Delete");
				meteorsToDelete.Add (tempMeteor);
			}
		}
		foreach (GameObject tempMeteor in meteorsToDelete) {
			meteorList.Remove (tempMeteor);
			Destroy (tempMeteor);
		}


	}


	void generateMeteors(){
		
		var offset = new Vector3 ( - HorizontalTiles / 2, - VerticalTiles / 2, 0);
		transform.position = new Vector3((int)Player.position.x,(int)Player.position.y,Player.position.z);
		StartCoroutine ("deleteMeteors");
		//deleteMeteors ();
		for (int x = 0; x < HorizontalTiles; x++) {
			for (int y = 0; y < VerticalTiles; y++) {
				Vector3 meteorPos = new Vector3 (x + (int)transform.position.x, y + (int)transform.position.y, 0.0f) + offset;
				if (nearestSpawn < Vector3.Distance (transform.position, meteorPos)) {
					Debug.Log (transform.position);
					if (RandomMeteorGen (x + (int)transform.position.x, y + (int)transform.position.y) > 8) {
						GameObject newMeteor= Instantiate (meteorPrefab, meteorPos, Quaternion.identity);
						meteorList.Add (newMeteor);
					}
				}

			}
		}
	}


	void Start () {
		meteorList = new List<GameObject> ();
		generateMeteors ();
	}
	
	// Update is called once per frame
	void Update () {
		if(MaxDistanceFromCenter<Vector3.Distance(Player.position,transform.position)){
			generateMeteors ();
		}
	}
}
