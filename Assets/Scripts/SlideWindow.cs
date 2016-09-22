using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlideWindow : MonoBehaviour {

	public Animator anim;
	public Text text;

	private int i = 1;

	public void TriggerSliding() {
		anim.SetTrigger ("ShowHide");
		ChangeText();
	}

	private void ChangeText() {
		if (i%2 == 0) {
			text.text = "Show planet info";
		} else {
			text.text = "Hide planet info";
		}
		i++;
	}
}
