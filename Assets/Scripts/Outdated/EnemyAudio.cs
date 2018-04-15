using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour {

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

	public void playSound(EnemySounds name){
		audioSource.PlayOneShot (clipList [(int)name]);
	}

}

public enum EnemySounds{
	Fire,
	Crash,
}