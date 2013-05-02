using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	public GameObject bullet;
	public float bulletSpeed = 10;
	public float shotTime = 0.5f;
	
	public int numBullets = 1;
	public float bulletAngleIncrement = 5;
	
	public float currentBulletAngle = 0;
	
	public bool gunEnabled = false;
	
	private float curDownTime = 0;
	private bool canShoot = true;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if( gunEnabled )
		{
			if( canShoot )
			{
				if( Input.GetButton("Shoot") )
				{
					Fire();
				}
			}
			else
			{
				curDownTime += Time.deltaTime;
				
				if( curDownTime >= shotTime )
				{
					canShoot = true;
					curDownTime = 0;
				}
			}
		}
	}
	
	private void Fire()
	{
		float fireAngle = currentBulletAngle * -1;
		
		if( numBullets % 2 == 0 )
		{
			for( int i = 0; i < numBullets; i++ )
			{
				if( i == numBullets * 0.5f )
				{
					fireAngle += bulletAngleIncrement;
				}
				
				// Calculate angle of instantiation
				float angleInRadians = fireAngle * Mathf.PI / 180;
				Debug.Log(angleInRadians.ToString());
				float x = Mathf.Sin(angleInRadians) * bulletSpeed;
				float y = Mathf.Cos(angleInRadians) * bulletSpeed;
				Vector3 shotVector = new Vector3(x,y,0);
				
				InstantiateBullet(shotVector);
				fireAngle += bulletAngleIncrement;
			}
		}
		else
		{
			for( int i = 0; i < numBullets; i++ )
			{
				// Calculate angle of instantiation
				float angleInRadians = fireAngle * Mathf.PI / 180;
				float x = Mathf.Sin(angleInRadians) * bulletSpeed;
				float y = Mathf.Cos(angleInRadians) * bulletSpeed;
				Vector3 shotVector = new Vector3(x,y,0);
				
				InstantiateBullet(shotVector);
				fireAngle += bulletAngleIncrement;
			}
		}
	}
	
	private void InstantiateBullet(Vector3 velocity)
	{
		// Instantiate bullet
		GameObject tempObj = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
		tempObj.rigidbody.velocity = velocity;
		tempObj.name = bullet.name;
		canShoot = false;
	}
	
	public void AddBullet()
	{
		numBullets++;
		
		if( numBullets % 2 == 0 )
		{
			currentBulletAngle += bulletAngleIncrement;
		}
	}
	
	public void RemoveBullet()
	{
		if( numBullets % 2 == 0 )
		{
			currentBulletAngle -= bulletAngleIncrement;
		}
		numBullets--;
	}
}
