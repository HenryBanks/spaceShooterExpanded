using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform trackingTarget;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position=new Vector3(trackingTarget.position.x, trackingTarget.position.y, transform.position.z);
	}
}
