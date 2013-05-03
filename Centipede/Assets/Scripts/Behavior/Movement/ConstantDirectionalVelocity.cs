using UnityEngine;
using System.Collections;

public class ConstantDirectionalVelocity : MonoBehaviour {
	
	public bool moveOnX = false;
	public bool moveOnY = false;
	public bool moveOnZ = false;
	
	public float speed = 5f;
	
	// Update is called once per frame
	void Update () {
		
		Vector3 currentVelocity = rigidbody.velocity;
		
		if( moveOnX )
		{
			if( currentVelocity.x == 0 || currentVelocity.x != speed )
			{
				float difference = speed - currentVelocity.x; 
				currentVelocity.x += difference;
			}
		}
		
		if( moveOnY )
		{
			if( currentVelocity.y == 0 || currentVelocity.y != speed )
			{
				float difference = speed - currentVelocity.y; 
				currentVelocity.y += difference;
			}
		}
		
		if( moveOnZ )
		{
			if( currentVelocity.z == 0 || currentVelocity.z != speed )
			{
				float difference = speed - currentVelocity.y; 
				currentVelocity.z += difference;
			}
		}
		
		rigidbody.velocity = currentVelocity;
	}
}
