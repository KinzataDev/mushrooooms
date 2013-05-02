using UnityEngine;
using System.Collections;

public class RandomRangedVelocity : MonoBehaviour {
	
	public bool randomizeX = false;
	public bool randomizeY = false;
	public bool randomizeZ = false;
	
	public float minSpeed = 2;
	public float maxSpeed = 5;
	
	public float minTimeBeforeChange = 1f;
	public float maxTimeBeforeChange = 4f;
	
	private float currentChangeTime;
	private float changeTimer = 0f;
	
	// Use this for initialization
	void Start () {
		currentChangeTime = Random.Range(minTimeBeforeChange, maxTimeBeforeChange);
	}
	
	// Update is called once per frame
	void Update () {
	
		changeTimer += Time.deltaTime;
		
		if( changeTimer >= currentChangeTime )
		{
			Vector3 newVelocity = Vector3.zero;
			if( randomizeX )
			{	
				float x = randomizeMaxMin();
				
				newVelocity.x = x;
			}
			
			if( randomizeY )
			{
				float y = randomizeMaxMin();
				newVelocity.y = y;
			}
			
			if( randomizeZ )
			{
				float z = randomizeMaxMin();
				newVelocity.z = z;
			}
			
			gameObject.rigidbody.velocity = newVelocity;
			currentChangeTime = Random.Range(minTimeBeforeChange, maxTimeBeforeChange);
			changeTimer = 0;
		}
		
	}
	
	private float randomizeMaxMin()
	{
		if( Random.value > 0.5f )
		{
			return Random.Range(minSpeed,maxSpeed);
		}
		else
		{
			return Random.Range(-minSpeed, -maxSpeed);	
		}
	}
}
