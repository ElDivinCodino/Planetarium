using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeCameraRotation : MonoBehaviour {

	private GameObject[] supports;

	// Use this for initialization
	void Start () {
		supports = GameObject.FindGameObjectsWithTag ("Camera Support");
	}

	public void ChangeCamRotType() {
		bool isStatic = !supports[0].GetComponent<CameraRotationNull> ().staticCam;
		foreach(GameObject support in supports) {
			support.GetComponent<CameraRotationNull>().staticCam = isStatic;
		}
		if (isStatic) {
			ChangeLabel ("Static Camera");
		} else {
			ChangeLabel ("Driven Camera");
		}
	}

	public void ChangeLabel(string str) {
		GetComponentInChildren<Text> ().text = str;
	}
}
