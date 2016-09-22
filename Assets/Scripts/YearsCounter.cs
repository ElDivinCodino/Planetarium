using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YearsCounter : MonoBehaviour {

	private string text;
	private int counter;
	private CelestialRotation earthRot;
	private float degreesRidden;

	public Text counterText;

	void Start () {
		counter = 0;
		ModifyString (counter);
		earthRot = GameObject.Find ("Earth").GetComponent<CelestialRotation>();
		degreesRidden = 0;
	}

	void FixedUpdate() {
		degreesRidden += earthRot.degrees;
		if (degreesRidden >= 360f) {
			counter++;
			ModifyString (counter);
			degreesRidden = 0;
		}
	}

	void ModifyString(int i) {
		text = "Years past on Earth: " + i;
		counterText.text = text;
	}
}
