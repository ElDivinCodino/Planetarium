using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeScale : MonoBehaviour {

	public MoveAerial controlAereal;
	public ChangeFocus changeFocus;
	public GameObject faidingPanel;

	private GameObject[] planets;

	void Start() {
		planets = GameObject.FindGameObjectsWithTag ("Planet");
	}

	public void SetScale(int num) {
		switch (num) {
		case 0:
			controlAereal.Reset ();
			ChangeCamera ("Main Camera");
			ShowTextFading ("Labels size based on planets sizes");
			Shrink (1000f);
			GameObject.Find ("Sun light").GetComponent<Light> ().range = 100;
			break;
		case 1:
			controlAereal.Reset ();
			ChangeCamera ("Proportional Camera");
			ShowTextFading ("Labels size based also on distances (farther, smaller)");
			Widen (1000f);
			GameObject.Find ("Sun light").GetComponent<Light> ().range = 10000;
			break;
		}
	}

	private void Widen(float i) {
		Vector3 planetPos;
		Vector3 otherPos;
		foreach (GameObject planet in planets) {
			if (planet.name.Equals ("Moon")) {
				planet.GetComponent<MoonRotation> ().distance = 3.85f;
			} else if (!planet.name.Equals ("Sun")) {
				planetPos = planet.transform.position; // subtract it from new position so that MoveTowards starts exactly from target epicenter and not from target + temp
				otherPos = planet.GetComponent<CelestialRotation> ().satelliteOf.transform.position;
				planet.transform.position = Vector3.MoveTowards (planetPos, otherPos, Mathf.Abs(Vector3.Distance (otherPos, planetPos) - 7) * -i) - planetPos;
			}
			planet.GetComponent<TrailRenderer> ().Clear ();
		}
	}

	private void Shrink(float i) {
		Vector3 planetPos;
		Vector3 otherPos;
		foreach (GameObject planet in planets) {
			if (planet.name.Equals ("Moon")) {
				planet.GetComponent<MoonRotation> ().distance = 0.634f;
			} else if (!planet.name.Equals ("Sun")) {
				planetPos = planet.transform.position; // subtract it from new position so that MoveTowards starts exactly from target epicenter and not from target + temp
				otherPos = planet.GetComponent<CelestialRotation> ().satelliteOf.transform.position;
				planet.transform.position = Vector3.MoveTowards (otherPos, planetPos, Mathf.Abs((Vector3.Distance (otherPos, planetPos) / i) + 7));
			}
			planet.GetComponent<TrailRenderer> ().Clear ();
		}
	}

	private void ChangeCamera(string currentCam) {
		GameObject.Find ("Proportional Camera").GetComponent<Camera> ().enabled = false;
		GameObject.Find ("Main Camera").GetComponent<Camera> ().enabled = false;
		Camera cam = GameObject.Find (currentCam).GetComponent<Camera> ();
		cam.enabled = true;

		CameraFacingBillboard[] billboards = GameObject.FindObjectsOfType (typeof(CameraFacingBillboard)) as CameraFacingBillboard[];
		foreach(CameraFacingBillboard bill in billboards) {		// change cam to face
			bill.ChangeCamera (cam);
		}

		if(!changeFocus.aerialView) {			// useful if you change scale meanwhile you are in prospective mode; altough camera starts 90 degrees rotated on x axis
			cam.transform.rotation = Quaternion.Euler(Vector3.zero);
		}

		GameObject[] planets = GameObject.FindGameObjectsWithTag ("Planet");
		GameObject[] planetLabels = GameObject.FindGameObjectsWithTag ("PlanetLabel");


		changeFocus.cam = cam.gameObject;
		controlAereal.cam = cam.gameObject;

		GameObject.Find ("CameraController").GetComponent<MoveCamera> ().cam = cam.gameObject;

		if(currentCam.Equals("Proportional Camera")) {
			controlAereal.multiplier = 50;
			controlAereal.sliders [2].value = 0; // necessary to trigger the OnValueChanged() function if no zoom was previously done
			controlAereal.sliders [2].value = 90;
			foreach(GameObject planet in planets) {
				planet.GetComponent<TrailRenderer> ().startWidth = 100f;
				planet.GetComponent<TrailRenderer> ().endWidth = 100f;
			}
			foreach(GameObject label in planetLabels) {
				label.transform.localScale *= 2000;
			}
		} else {
			controlAereal.multiplier = 1;
			controlAereal.sliders [2].value = 0; // necessary to trigger the OnValueChanged() function if no zoom was previously done
			controlAereal.sliders [2].value = 90;
			foreach(GameObject planet in planets) {
				planet.GetComponent<TrailRenderer> ().startWidth = 0.1f;
				planet.GetComponent<TrailRenderer> ().endWidth = 0.1f;
			}
			foreach(GameObject label in planetLabels) {
				label.transform.localScale /= 2000;
			}
		}
	}

	private void ShowTextFading(string str) {
		faidingPanel.GetComponentInChildren<Text> ().text = str;
		faidingPanel.GetComponent<Animator> ().SetTrigger ("TextIn");
	}
}
