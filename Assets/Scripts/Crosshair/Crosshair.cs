using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class Crosshair : MonoBehaviour {

	// Event Names to call on objects
	const string OnCrosshairExitMessage = "OnCrosshairExit";
	const string OnCrosshairEnterMessage = "OnCrosshairEnter";
	const string OnCrosshairClickMessage = "OnCrosshairClick";

	// Enum for Modes
	public enum Mode {
		Dynamic,
		Fixed
	}

	// Set the default Mode
	public Mode CurrentMode = Mode.Fixed;

	// The distance the crosshair should be from the camera in Fixed Mode
	public float FixedModeDistance = 10.0f;

	// The Camera the crosshair is associated with
	public Camera attachedCamera;

	// The distance the ray should travel when looking for objects
	public float maxAffectedDistance = 10f;

	// Object we've hit with the ray, if any
	internal GameObject hitObject;

	// Use this for initialization
	void Start () {
		initCrosshair ();
	}
	
	// Update is called once per frame
	void Update () {
		// Update the crosshair position
		updatePosition ();

		// Check if there are any objects we've hit with the crosshair
		checkForObjects ();
	}

	// Perform inital setup and positioning of the crosshair
	void initCrosshair() {
		// Ensure we are attached to a camera
		if (!attachedCamera)
			attachedCamera = Camera.main;

		// Position the Crosshair in the center of the camera, at a specified distance away
		transform.position = attachedCamera.ScreenToWorldPoint (new Vector3(Screen.width/2, Screen.height/2, FixedModeDistance));
	}

	// Since the crosshair is required to be in world space, we reposition the crosshair each frame
	void updatePosition() {

		// Then make sure it's rotated to face to camera
		transform.LookAt (attachedCamera.transform.position);

		if (CurrentMode == Mode.Dynamic && hitObject) {
			
			// If we're using dynamic mode and we've hit an object, move the crosshair in front
			transform.position = attachedCamera.ScreenToWorldPoint (new Vector3(Screen.width/2, Screen.height/2, hitObject.transform.position.z));

		} else if (CurrentMode == Mode.Fixed || (CurrentMode == Mode.Dynamic && !hitObject)) {
			
			// Center the crosshair and position it at the required distance
			transform.position = attachedCamera.ScreenToWorldPoint (new Vector3(Screen.width/2, Screen.height/2, FixedModeDistance));

		}
	}

	// Check if there are objects that are under the crosshair.
	void checkForObjects() {
		RaycastHit hit;

		// Cast a ray from the center of the camera and see if we've hit anything
		if (Physics.Raycast(attachedCamera.transform.position, attachedCamera.transform.forward, out hit, maxAffectedDistance))
		{
			// We've hit something, check if it's new
			GameObject newHitObject = hit.collider.gameObject;
			if (hitObject != newHitObject)
			{
				// New Object, Send a message to the object to let it know.
				SendMessageTo (hitObject, OnCrosshairExitMessage);
				hitObject = newHitObject;
				SendMessageTo (hitObject, OnCrosshairEnterMessage);
			}

			// The user clicked on the object, send a message letting the object know that too
			if (Input.GetMouseButtonDown (0)) {
				SendMessageTo (newHitObject, OnCrosshairClickMessage);
			}
		}
		else
		{
			// We dont have an object, let the object know and reset
			SendMessageTo(hitObject, OnCrosshairExitMessage);
			hitObject = null;
		}
	}

	// A convienience function for sending messages to a specific object
	void SendMessageTo(GameObject target, string message)
	{
		if (target)
			target.SendMessage(message, gameObject,
				SendMessageOptions.DontRequireReceiver);
	}
}
