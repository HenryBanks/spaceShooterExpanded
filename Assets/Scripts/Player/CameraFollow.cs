using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	Vector3 trackingTarget;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Player.instance != null) {
			trackingTarget = Player.instance.transform.position;
			transform.position = new Vector2 (trackingTarget.x, trackingTarget.y);
		}
	}
}
