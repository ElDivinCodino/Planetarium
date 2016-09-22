using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetSlider : MonoBehaviour {

	private Slider slider;

	void Start() {
		slider = GetComponent<Slider> ();
	}

	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			slider.value = 0;
		}
	}
}
