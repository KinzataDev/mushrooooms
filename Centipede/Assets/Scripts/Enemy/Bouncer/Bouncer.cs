using UnityEngine;
using System.Collections;

public class Bouncer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 explosionPos = transform.position;
		Vector2 temp = Random.insideUnitCircle.normalized;
		explosionPos[0] += temp[0];
		explosionPos[1] += temp[1];
		explosionPos[2] = 0;
		explosionPos *= 10;
		
		gameObject.rigidbody.AddExplosionForce(2000.0f, explosionPos, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 tempVector = transform.position;
		if( tempVector[2] != 0 )
		{
			tempVector[2] = 0;
			transform.position = tempVector;
		}
	}
}
