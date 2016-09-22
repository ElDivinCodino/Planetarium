using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveAerial : MonoBehaviour {

	public Slider[] sliders;
	public int multiplier;
	public GameObject cam;

	private Vector3 pos;

	void Start() {
		pos = cam.transform.position;
		multiplier = 1;
	}

	void Update() {
		cam.transform.position = pos;
	}

	public void ZoomInOut(float m) {
		pos.y = m * multiplier; 
	}

	public void MoveRightLeft(float m) {
		pos.x = m * multiplier;
	}

	public void MoveUpDown(float m) {
		pos.z = m * multiplier;
	}

	public void Reset() {
		foreach(Slider sl in sliders) {
			if(sl.name != "ZoomInOut") {
				sl.value = 0;
			} else {
				sl.value = 90;
			}
		}
	}
}
