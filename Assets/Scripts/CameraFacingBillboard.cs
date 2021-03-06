﻿using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour {

	private Camera m_Camera;

	void Awake() {
		m_Camera = Camera.main;
	}

	void Update()
	{
		transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
			m_Camera.transform.rotation * Vector3.up);
	}

	public void ChangeCamera(Camera cam) {
		m_Camera = cam;
	}
}