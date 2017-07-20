using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShot : MonoBehaviour {
	
	public float moveSpeed=0.2f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 15f);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.CompareTag("meteor")||coll.gameObject.CompareTag("enemy")){
			ItemManager.instance.itemList.Remove (coll.gameObject);
			Destroy (coll.gameObject);
			playerScore.instance.addScore (10);
		}
		Debug.Log ("hit");
		Destroy (gameObject);
	}

	// Update is called once per frame
	void FixedUpdate () {
	}

	void Update(){
		//transform.Translate (transform.up * moveSpeed * Time.deltaTime);
	}
}
