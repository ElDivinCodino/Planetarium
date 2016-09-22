using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (this);
		if (AudioAlreadyExisting()) { 	// if this AudioSource is not the currently playing
			Destroy (gameObject);		// destroy it
		}
	}

	private bool AudioAlreadyExisting() {
		GameObject[] audioSources;
		audioSources = GameObject.FindGameObjectsWithTag ("AudioManager");
		if (audioSources.Length > 1) {
			return true;
		} else {
			return false;
		}
	}
}
