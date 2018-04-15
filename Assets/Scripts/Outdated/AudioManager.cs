using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[SerializeField]
	AudioClip[] clipList;

	AudioSource audioSource;


	public static AudioManager instance;

	void Awake(){
		audioSource = GetComponent<AudioSource> ();
		instance = this;
	}

	public void playSound(SoundName name){
		audioSource.PlayOneShot (clipList [(int)name]);
	}
}

public enum SoundName{
	Fire,
	ShieldDown,
	ShieldUp,
	Crash,
}