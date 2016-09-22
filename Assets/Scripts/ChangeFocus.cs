using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeFocus: MonoBehaviour {

	private Vector3 resetPos;
	private Quaternion resetRot;
	private string planetName;
	private GameObject planet;

	[HideInInspector]public bool aerialView;
	public Toggle showLabel;
	public InfoWriter info;
	public ImageChanger sprite;
	public GameObject cam;
	public ChangeCameraRotation camRotToggle;
	public MoveCamera moveCam;

	void Start () {
		resetPos = cam.transform.position;
		resetRot = cam.transform.rotation;
		aerialView = true;
		planetName = "Select a planet";
		planet = GameObject.Find ("Sun");
	}

	void LateUpdate () {
		if(!aerialView) {
			FocusOn ();
		}
	}

	public void SetView(bool b) {
		aerialView = b;
		if (b == true) {
			Aerial ();
		} else {
			cam.transform.rotation = Quaternion.identity;
		}
	}

	public void SetPlanet(int num) {
		string[] planetData = new string[6];
		switch (num) {
		case 0:
			planetName = "Select a planet";
			planetData[0] = "";
			break;
		case 1:
			planetName = "Sun";
			planetData[0] = "332,800";
			planetData[1] = "1392";
			info.fixedText[2] = "Rotation period: ";
			planetData[2] = "26-37 d";
			info.fixedText[3] = "Mean distance to Earth (10^6 km): ";
			planetData[3] = "149";
			planetData[4] = "1.41";
			planetData[5] = "274";
			break;
		case 2:
			planetName = "Mercury";
			planetData[0] = "0.0558";
			planetData[1] = "4.88";
			info.fixedText[2] = "Period (years): ";
			planetData[2] = "0.241";
			info.fixedText[3] = "Mean distance from Sun (10^6 km): ";
			planetData[3] = "57.9";
			planetData[4] = "5.60";
			planetData[5] = "3.78";
			break;
		case 3:
			planetName = "Venus";
			planetData[0] = "0.816";
			planetData[1] = "12.104";
			info.fixedText[2] = "Period (years): ";
			planetData[2] = "0.615";
			info.fixedText[3] = "Mean distance from Sun (10^6 km): ";
			planetData[3] = "108.2";
			planetData[4] = "5.243";
			planetData[5] = "8.87";
			break;
		case 4:
			planetName = "Moon";
			planetData[0] = "0.0123";
			planetData[1] = "3.475";
			info.fixedText[2] = "Period (days): ";
			planetData[2] = "27.3";
			info.fixedText[3] = "Mean distance from Earth (10^3 km): ";
			planetData[3] = "0.384";
			planetData[4] = "3.34";
			planetData[5] = "1.6";
			break;
		case 5:
			planetName = "Earth";
			planetData[0] = "1.00";
			planetData[1] = "12.756";
			info.fixedText[2] = "Period (years): ";
			planetData[2] = "1.00";
			info.fixedText[3] = "Mean distance from Sun (10^6 km): ";
			planetData[3] = "149.6";
			planetData[4] = "5.514";
			planetData[5] = "9.8";
			break;
		case 6:
			planetName = "Mars";
			planetData[0] = "0.107";
			planetData[1] = "6.79";
			info.fixedText[2] = "Period (years): ";
			planetData[2] = "1.88";
			info.fixedText[3] = "Mean distance from Sun (10^6 km): ";
			planetData[3] = "228";
			planetData[4] = "3.95";
			planetData[5] = "3.72";
			break;
		case 7:
			planetName = "Jupiter";
			planetData[0] = "318";
			planetData[1] = "143";
			info.fixedText[2] = "Period (years): ";
			planetData[2] = "11.9";
			info.fixedText[3] = "Mean distance from Sun (10^6 km): ";
			planetData[3] = "778";
			planetData[4] = "1.31";
			planetData[5] = "22.9";
			break;
		case 8:
			planetName = "Saturn";
			planetData[0] = "95.1";
			planetData[1] = "120";
			info.fixedText[2] = "Period (years): ";
			planetData[2] = "29.5";
			info.fixedText[3] = "Mean distance from Sun (10^6 km): ";
			planetData[3] = "1,430";
			planetData[4] = "0.704";
			planetData[5] = "9.05";
			break;
		case 9:
			planetName = "Uranus";
			planetData[0] = "146";
			planetData[1] = "51.8";
			info.fixedText[2] = "Period (years): ";
			planetData[2] = "84.0";
			info.fixedText[3] = "Mean distance from Sun (10^6 km): ";
			planetData[3] = "2,870";
			planetData[4] = "1.21";
			planetData[5] = "7.77";
			break;
		case 10:
			planetName = "Neptune";
			planetData[0] = "17.2";
			planetData[1] = "49.5";
			info.fixedText[2] = "Period (years): ";
			planetData[2] = "165";
			info.fixedText[3] = "Mean distance from Sun (10^6 km): ";
			planetData[3] = "4,500";
			planetData[4] = "1.67";
			planetData[5] = "11.0";
			break;
		}
		info.data = planetData;
		sprite.ChangeSprite (num);

		if (!aerialView) {
			moveCam.changeVer (0);
			moveCam.changeHor (0);
		}
	}

	void FocusOn() {
		if (planetName != "Select a planet") {
			planet = GameObject.Find (planetName);
			cam.transform.parent.transform.SetParent (planet.transform.Find("CameraSupport").transform);
			cam.transform.position = planet.transform.FindChild("CameraSupport").transform.position;
			Camera setPropCam = GameObject.Find ("Proportional Camera").GetComponent<Camera> ();
			setPropCam.fieldOfView = 60;
			setPropCam.clearFlags = CameraClearFlags.Skybox;
		} 
	}

	void Aerial() {
		
		GameObject[] supports = GameObject.FindGameObjectsWithTag ("Camera Support");

		foreach(GameObject support in supports) {
			support.GetComponent<CameraRotationNull>().staticCam = true;
		}
		camRotToggle.ChangeLabel ("Static Camera");

		cam.transform.position = resetPos;
		cam.transform.rotation = resetRot;

		cam.transform.parent.transform.SetParent (null);

		Camera setPropCam = GameObject.Find ("Proportional Camera").GetComponent<Camera> ();
		setPropCam.fieldOfView = 170;
		setPropCam.clearFlags = CameraClearFlags.SolidColor;
	}
}
