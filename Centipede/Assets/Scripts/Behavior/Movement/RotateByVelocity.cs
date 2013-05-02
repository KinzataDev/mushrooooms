using UnityEngine;
using System.Collections;

public class RotateByVelocity : MonoBehaviour {
	
	public bool rotateOnX = false;
	public bool rotateOnY = false;
	public bool rotateOnZ = false;
	
	public float maxRotation = 25f;
	public float topVelocity = 10f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 rotationVector = Vector3.zero;
		
		if( rotateOnX )
		{
			float yVelocity = gameObject.rigidbody.velocity.y;
			float yScale = (yVelocity > 0) ? (Mathf.Min(topVelocity, yVelocity)) : ((Mathf.Max(-topVelocity, yVelocity)));
			yScale /= topVelocity;
			float rotX = maxRotation * yScale;
			rotationVector.x = rotX;
		}
		
		if( rotateOnY )
		{
			
			float xVelocity = gameObject.rigidbody.velocity.x;
			float xScale = (xVelocity > 0) ? (Mathf.Min(topVelocity, xVelocity)) : ((Mathf.Max(-topVelocity, xVelocity)));
			xScale /= topVelocity;
			float rotY = maxRotation * xScale;
			rotationVector.y = -rotY;
		}
		
		
		gameObject.transform.rotation = Quaternion.Euler(rotationVector);
		
		
	}
}
