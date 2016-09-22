using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Class goal is to set default color and runtime position/dimension of planet labels
 * */

public class FollowPlanet : MonoBehaviour {

	public GameObject planet;
	[HideInInspector]public Vector3 rotation;
	[HideInInspector]public Vector3 offset;	// how much label has to be from the planet
	public Toggle aerial;

	private Vector3 realOffset;	// where the label has to be in real time
	private TextMesh label;
	private int multiplier = 20;	// to make labels readable enough

	void Start () {
		label = gameObject.GetComponent<TextMesh> ();
		label.color = planet.GetComponent<TrailRenderer> ().materials [0].GetColor("_TintColor"); // give label same color as trace
		label.fontSize = Mathf.Clamp(Mathf.CeilToInt(700 * planet.transform.lossyScale.x), 30, 400);	// font size based on planet size
		offset = new Vector3 (0, 0, Mathf.Abs(planet.transform.lossyScale.x/2f) + (label.fontSize / 100)); // necessary to put label above the planet in aerial view
	}
		
	void FixedUpdate () {
		realOffset = planet.transform.position + offset;
		Move ();
		Resize ();
	}

	void Move() {
		transform.position = realOffset;

		if (aerial.isOn) {
			offset = new Vector3 (0, 0, Mathf.Abs(planet.transform.lossyScale.x/2f) + (label.fontSize / 100)); // necessary to put label above the planet in aerial view
		} else {
			offset = new Vector3 (0, planet.transform.lossyScale.x, 0);
		}
	}

	void Resize() {
		if (aerial.isOn) {
			label.characterSize = 0.1f;
		} else {
			label.characterSize = Mathf.Max(Vector3.Distance(Camera.main.gameObject.transform.position, planet.transform.position), 1) * multiplier / (MaxDistance() * label.fontSize);	// resize character based on distance from camera
			if ((planet.name.Equals("Moon") || planet.name.Equals("Earth")) && Camera.main.gameObject.name.Equals("Proportional Camera")) {	// otherwise Moon label gets too small to be visible from Earth
				label.characterSize = Mathf.Max (label.characterSize, 0.0001f);
			}
		}
	}

	/**
	 * Calculate distance between current camera position and the farthest planet
	 * */
	private float MaxDistance() {
		GameObject[] labels = GameObject.FindGameObjectsWithTag ("PlanetLabel");
		float max = 0f;
		foreach (GameObject lbl in labels) {
			if (Vector3.Distance(Camera.main.gameObject.transform.position, lbl.transform.position) > max) {
				max = Vector3.Distance (Camera.main.gameObject.transform.position, lbl.transform.position);
			}
		}
		return max;
	}
}
