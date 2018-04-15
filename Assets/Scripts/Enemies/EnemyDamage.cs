using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : Destructible {

	
	[SerializeField]
	GameObject explosionPrefab;

	bool destroying=false;

	public override void TakeDamage(int damage){
		health -= damage;
		if (health <= 0 && !destroying) {
			destroying = true;
			StatsTracker.instance.EnemyDestroyed();
			StartCoroutine (DestroyAfterDelay ());
			//			ItemManager.instance.itemList.Remove (gameObject);
			//			var dest=Instantiate (destroyedMeteor, transform.position, transform.rotation);
			//			foreach (Rigidbody2D child in dest.GetComponentsInChildren<Rigidbody2D>()) {
			//				child.velocity = GetComponent<Rigidbody2D> ().velocity;
			//			}
			//			Destroy (gameObject);
		}
	}

	private IEnumerator DestroyAfterDelay(){

		yield return new WaitForSeconds (0.0f);


		ItemManager.instance.itemList.Remove (gameObject);
		if (explosionPrefab != null) {
			var dest = Instantiate (explosionPrefab, transform.position, transform.rotation);
			foreach (Rigidbody2D child in dest.GetComponentsInChildren<Rigidbody2D>()) {
				child.velocity = GetComponent<Rigidbody2D> ().velocity + (Vector2)child.transform.localPosition;
			}
		}
		Destroy (gameObject);
	}


}
