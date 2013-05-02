using UnityEngine;
using System.Collections;

public class ConstantVelocity : MonoBehaviour {
	
	public float speed;
	
	void Update () {
		Vector3 currentVelocity = rigidbody.velocity;
		
		if( currentVelocity.magnitude != 0 && currentVelocity.magnitude != speed )
		{
			float difference = speed / currentVelocity.magnitude;
			currentVelocity *= difference;
			rigidbody.velocity = currentVelocity;
		}
	}
}
