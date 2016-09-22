using UnityEngine;
using System.Collections;

public class ShowFAQ : MonoBehaviour {

	public GameObject panel;

	public void ShowHideFAQ() {
		bool b = panel.activeInHierarchy;
		panel.SetActive (!b);
	}
}
