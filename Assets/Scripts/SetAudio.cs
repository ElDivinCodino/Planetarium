using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetAudio : MonoBehaviour {

	public Sprite audioOn;
	public Sprite audioOff;

	private AudioSource music;
	private Image sprite;

	public void Start() {
		music = GameObject.Find ("Audio manager").GetComponent<AudioSource> ();
		sprite = GetComponent<Image> ();
	}

	public void AudioSwitch() {
		if (music.isPlaying) {
			music.Pause ();
			sprite.overrideSprite = audioOff;
		} else {
			music.Play ();
			sprite.overrideSprite = audioOn;
		}
	}

	public void VolumeChanger(float vol) {
		music.volume = vol;
	}
}
