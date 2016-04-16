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
	public void OnCrosshairEnter (GameObject sender) {
		print ("Crosshair Entered!");
		rigidBody.useGravity = true;
	}

	// When crosshair exits
	public void OnCrosshairExit (GameObject sender) {
		print ("Crosshair Exited!");
	}
}
