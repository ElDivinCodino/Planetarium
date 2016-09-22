using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ValueChanger : MonoBehaviour {

	public Slider slider;
	public InputField inputField;
	public GameObject manager;

	public void changeValue(float val) {
		inputField.GetComponent<InputField> ().text = val.ToString();
		manager.GetComponent<GameManager>().globalSpeed = val;
	}

	public void changeValue(string val) {
		float result;
		if (float.TryParse(val, out result)) {
			slider.value = result;
			manager.GetComponent<GameManager>().globalSpeed = result;
		} else {
			Debug.Log("Please insert a correct value. It must be a float.");
		}
	}
}
