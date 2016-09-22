using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public Slider sliderVer;
	public InputField inputFieldVer;
	public Slider sliderHor;
	public InputField inputFieldHor;
	public GameObject cam;
	public Toggle aerial;

	private Vector3 rot;
	private Vector3 pos;
	private bool YAxisInv;
	private bool XAxisInv;
	private GameObject[] camRots;
	private GameObject[] camMovs;

	void Awake() {
		camRots = GameObject.FindGameObjectsWithTag ("PerspectiveController");
		camMovs = GameObject.FindGameObjectsWithTag ("AerialController");
	}

	void Update() {
		if (aerial.GetComponent<Toggle>().isOn) {
			foreach(GameObject g in camRots) {
				g.SetActive (false);
			}
			foreach(GameObject g in camMovs) {
				g.SetActive (true);
			}
		} else {
			foreach(GameObject g in camRots) {
				g.SetActive (true);
			}
			foreach(GameObject g in camMovs) {
				g.SetActive (false);
			}
		}
	}

	public void changeVer(float val) {
		if (YAxisInv) {
			pos = new Vector3 (0, -val, 0);
		} else {
			pos = new Vector3 (0, val, 0);
		}
		inputFieldVer.GetComponent<InputField> ().text = val.ToString();

		if (cam.name == "Proportional Camera") {
			pos *= 600;
			sliderVer.wholeNumbers = true;
		} else {
			sliderVer.wholeNumbers = false;
		}
			
		if(cam.transform.parent.transform.parent != null)
			cam.transform.parent.transform.parent.GetComponent<Transform>().localPosition = pos; // you need to search not on the parent ("Cameras") but on the grand parent ("CameraSupport")
	}

	public void changeVer(string val) {
		float result;
		if (float.TryParse(val, out result)) {
			sliderVer.value = result;
		} else {
			Debug.Log("Please insert a correct value. It must be a float.");
		}
	}

	public void changeHor(float val) {
		if (XAxisInv) {
			rot = new Vector3 (rot.x, -val, rot.z);
		} else {
			rot = new Vector3 (rot.x, val, rot.z);
		}
		inputFieldHor.GetComponent<InputField> ().text = val.ToString();
		cam.transform.rotation = Quaternion.Euler(rot);
	}

	public void changeHor(string val) {
		float result;
		if (float.TryParse(val, out result)) {
			sliderHor.value = result;
		} else {
			Debug.Log("Please insert a correct value. It must be a float.");
		}
	}

	public void SetX(bool b) {
		XAxisInv = b;
	}

	public void SetY(bool b) {
		YAxisInv = b;
	}
}