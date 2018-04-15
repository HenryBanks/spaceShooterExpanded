using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivePointer : MonoBehaviour {

	public static ObjectivePointer instance;
	Text distanceText;
	Image pointerSprite;
	RectTransform rectTransform;

	void Awake(){
		instance = this;
		distanceText = GetComponentInChildren<Text> ();
		pointerSprite = GetComponentInChildren<Image> ();
		rectTransform = GetComponent<RectTransform> ();
	}



	public void UpdatePointer(Vector2 objectivePosition){
		if (Player.instance != null) {
			Vector2 playerPosition = (Vector2)Player.instance.transform.position;
			Vector2 playerToObjective = objectivePosition - playerPosition;

			float angle = Mathf.Atan2 (playerToObjective.y, playerToObjective.x);
			//transform.position=playerPosition+new Vector2(Mathf.Cos(angle),Mathf.Sin(angle));
			rectTransform.anchoredPosition = new Vector2 (700 * Mathf.Cos (angle), 350 * Mathf.Sin (angle));

			pointerSprite.transform.right = playerToObjective;
			float distance = Vector3.Distance (objectivePosition, playerPosition);

			distanceText.text = distance.ToString ("F0") + " km";
		}
	}

}
