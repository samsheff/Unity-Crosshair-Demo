﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class BoxDropper : MonoBehaviour {

	Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = gameObject.GetComponent<Rigidbody> ();
	}
	
	// If the Crosshair enters
	void OnCrosshairEnter (GameObject sender) {
		print ("Crosshair Entered!");
	}

	// When crosshair exits
	void OnCrosshairExit (GameObject sender) {
		print ("Crosshair Exited!");
	}

	// When the crosshair is over the object and clicked
	void OnCrosshairClick (GameObject sender) {
		print ("Crosshair Clicked!");

		// Enable Gravity if we've clicked the object
		rigidBody.useGravity = true;
	}
}
