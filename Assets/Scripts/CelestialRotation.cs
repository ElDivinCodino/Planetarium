using UnityEngine;
using System.Collections;

/*
Manage the rotation of a celestial object
*/

public class CelestialRotation : MonoBehaviour
{

	private float maxDistance;

	public float speed;	// speed of rotation
	public float period; // orbit period relative to Earth's one (1/period in years)
	public float tilt;	// tilt of the rotation axis
	public GameObject satelliteOf;
	[HideInInspector]public float degrees;
	
	Transform myTransform;	// reference to the Transform component
	GameManager manager;	// reference to the game manager
	Vector3 epic;

	void Start ()
	{
		// get the reference to the Transform component and the GameManager component
		myTransform = GetComponent<Transform>();
		manager = GameObject.Find("Game manager").GetComponent<GameManager>();

		// initialize epicenter position
		epic = satelliteOf.GetComponent<Transform>().position;
		
		// initialize the celestial object's rotation according to the tilt angle
		myTransform.rotation = Quaternion.Euler(0f, 0f, tilt);
	}
	
	void FixedUpdate ()
	{
		// for each frame, rotate the celestial object with a speed defined by
		// the speed variable declared in this class as well as the global speed defined
		// in the GameManager component of the game manager
		myTransform.Rotate(Vector3.up * speed * manager.globalSpeed * Time.fixedDeltaTime);
		degrees = period * manager.globalSpeed * Time.fixedDeltaTime;
		myTransform.RotateAround (epic, Vector3.up, degrees);
		epic = satelliteOf.GetComponent<Transform>().position;
	}
}
