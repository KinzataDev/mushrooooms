using UnityEngine;
using System.Collections;

public class MouseMovement : MonoBehaviour {
	
	public Camera mainCamera;
	public float speed = 2;
	
	private Rect screenArea;
	private float lowDistanceDampenFactor = 10.0f;
	
	// Use this for initialization
	void Start () {
		mainCamera = Camera.mainCamera;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Get the mouse position
		Vector3 mousePos = Input.mousePosition;
		Vector3 inVector = mainCamera.ScreenToWorldPoint(mousePos);
		inVector[2] = 0;
		Vector3 curVector = transform.position;
		
		// Vector of the difference between mouse and player
		Vector3 differenceVector = inVector - curVector;
		
		Vector3 directionVector = differenceVector.normalized;
		
		// This is here to remove the jitter when the player is on the mouse position
		
		float scale = differenceVector.magnitude;
		Vector3 newSpeed = directionVector * scale * lowDistanceDampenFactor;
		
		// Cap the speed
		if( newSpeed.magnitude > speed)
		{
			newSpeed = newSpeed.normalized * speed;
		}
		
		gameObject.rigidbody.velocity = newSpeed;
		

	}
	
}
