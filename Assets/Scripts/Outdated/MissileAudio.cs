using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAudio : MonoBehaviour {

	AudioSource audioSource;
	[SerializeField]
	AudioClip[] clipList;

	// Use this for initialization
	void Awake () {
		audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void playSound(MissileSounds name){
		Debug.Log ("PLAY SOUND");
		audioSource.PlayOneShot (clipList [(int)name]);
	}

}

public enum MissileSounds{
	Crash,
}