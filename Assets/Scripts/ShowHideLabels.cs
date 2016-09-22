using UnityEngine;
using System.Collections;

public class ShowHideLabels : MonoBehaviour {

	private bool active;
	private GameObject[] planetLabels;

	void Start() {
		planetLabels = GameObject.FindGameObjectsWithTag ("PlanetLabel");
		active = true;
	}

	void Update () {
		foreach (GameObject label in planetLabels) {
			label.GetComponent<MeshRenderer> ().enabled = active;
		}
	}

	public void SetShowHide(bool b) {
		active = b;
	}
}
