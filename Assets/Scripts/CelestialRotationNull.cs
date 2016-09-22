using UnityEngine;
using System.Collections;

/*
Reset the GameObject rotation
*/

public class CelestialRotationNull : MonoBehaviour
{

	Transform myTransform;	// reference to the Transform component
	
	void Start ()
	{
		// get the reference to the Transform component
		myTransform = GetComponent<Transform>();
	}
	
	void FixedUpdate ()
	{
		// for each frame, reset the rotation of the GameObject:
		// Quaternion.identity corresponds to 'no rotation', so that the local space
		// coordinates are identical to the world space ones
		myTransform.rotation = Quaternion.identity;
	}
}
