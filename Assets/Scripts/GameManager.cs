using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/*
This component can be used by other components to access data
that can be useful to any object in the scene
*/

public class GameManager : MonoBehaviour
{
	// the global speed of the Planetarium simulation	
	public float globalSpeed = 10f;

	private float lastValue = 10f;

	public void Pause() {
		if(globalSpeed != 0f)
			lastValue = globalSpeed;
		globalSpeed = 0f;
	}

	public void Play() {
		globalSpeed = lastValue;
	}

	public void Reset() {
		SceneManager.LoadScene (0);
	}

	public void Quit() {
		Application.Quit ();
	}
}
