using UnityEngine;
using System.Collections;

public class CameraRotationNull : MonoBehaviour {

	Transform myTransform;
	Quaternion rot;
	float yRot;

	public bool staticCam;

	void Start ()
	{
		myTransform = GetComponent<Transform>();
		staticCam = false;
		rot = Quaternion.identity;
	}

	void FixedUpdate ()	
	{
		if (staticCam) {
			myTransform.rotation = rot;
		} else {
			rot = myTransform.rotation;
			rot.x = 0;
			rot.z = 0;
			myTransform.rotation = rot;
		}
	}
}
