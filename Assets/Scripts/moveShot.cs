using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShot : MonoBehaviour {
	
	public float moveSpeed=0.2f;
	[SerializeField]
	int shotDamage=20;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 15f);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log (coll.gameObject.tag);
		if (coll.gameObject.GetComponent<Destructible>()!=null){
			coll.gameObject.GetComponent<Destructible> ().TakeDamage (shotDamage);
		}else if(coll.gameObject.CompareTag("player")){
			coll.gameObject.GetComponent<PlayerDamage> ().TakeDamage (shotDamage);
		}
		//Debug.Log ("hit");
		Destroy (gameObject);
	}

	// Update is called once per frame
	void FixedUpdate () {
	}

	void Update(){
		//transform.Translate (transform.up * moveSpeed * Time.deltaTime);
	}
}
