using UnityEngine;
using System.Collections;

public class ShakeOnCollision : MonoBehaviour {
	
	public GameObject[] objects;
	
	public float shakeTime = 0.5f;
	private float currentShakeTime = 0;
	
	public float shakeForce = 1f;
	
	private bool isShaking = false;
	
	private Vector3 originalPosition;
	
	void Start()
	{
		originalPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( isShaking )
		{
			transform.position = originalPosition;
			currentShakeTime += Time.deltaTime;
			if( currentShakeTime >= shakeTime )
			{
				isShaking = false;
			}
			
			Vector3 newPosition = Random.insideUnitCircle;
			newPosition *= shakeForce;
			newPosition += transform.position;
			transform.position = newPosition;
		}
		else
		{
			transform.position = originalPosition;
		}
	}
	
	void Shake()
	{
		isShaking = true;
		currentShakeTime = 0;
	}
	
	void OnCollisionEnter(Collision hit)
	{	
		foreach( GameObject obj in objects )
		{
			if( obj.name == hit.gameObject.name )
			{
				Shake();
			}
		}
	}
}
