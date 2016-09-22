using UnityEngine;
using System.Collections;

public class ShowHideTraces : MonoBehaviour {

	private bool active;
	private GameObject[] planetTrails;

	void Start() {
		planetTrails = GameObject.FindGameObjectsWithTag ("Planet");
		active = true;
	}

	public void SetShowHide(bool b) {
		active = b;
		foreach (GameObject planet in planetTrails) {
			planet.GetComponent<TrailRenderer> ().enabled = active;
			if(active) {
				planet.GetComponent<TrailRenderer> ().Clear ();
			}
		}
	}
}
