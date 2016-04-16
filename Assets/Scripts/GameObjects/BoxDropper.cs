using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class BoxDropper : MonoBehaviour {

	Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody> ();
	}
	
	// If the Crosshair enters
	public void OnCrosshairEnter () {
		print ("Crosshair Entered!");
		rigidBody.useGravity = true;
	}

	public void OnCrosshairExit () {
		print ("Crosshair Exited!");
	}
}
