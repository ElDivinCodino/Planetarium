using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageChanger : MonoBehaviour {

	public Sprite[] sprites;

	public void ChangeSprite (int planet) {
		if (planet == 0) {
			GetComponent<Image> ().enabled = false;
		} else {
			GetComponent<Image> ().enabled = true;
			GetComponent<Image> ().sprite = sprites [planet];
		}
	}
}
