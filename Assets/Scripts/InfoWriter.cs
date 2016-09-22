using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoWriter : MonoBehaviour {

	[HideInInspector]public string[] fixedText = new string[6];
	[HideInInspector]public string[] data = new string[6];

	void Start() {
		fixedText[0] = "Mass (Earth = 1): ";
		fixedText[1] = "Mean diameter (10^3 km): ";
		fixedText[2] = "Period (years): ";
		fixedText[3] = "Mean distance from Sun (10^6 km): ";
		fixedText[4] = "Density (water = 1): ";
		fixedText[5] = "Surface gravity m/(s^2): ";
	}

	void Update() {
		GetComponent<Text> ().text = Write ();
	}

	private string Write() {
		string text = "";

		if (data [0] == "") {
			text = "Please select a planet in the drop-down menu below";
		} else {
			for (int i = 0; i < fixedText.Length; i++) {
				text += fixedText [i] + data [i] + "\n\n";
			}
		}
		return text;
	}
}
