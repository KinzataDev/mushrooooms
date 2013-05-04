using UnityEngine;
using System.Collections;

public class Gibber : MonoBehaviour {
	
	public GameObject[] gibs;
	public int gibCount = 10;
	
	public float maxExplosionForce = 1000f;
	public float minExplosionForce = 500f;
	
	public float spawnRadius = 1;
	
	public bool useZ = false;
	
	public void Gib()
	{
		for( int i = 0; i < gibCount; i++ )
		{
			GameObject obj = gibs[Random.Range(0,gibs.Length)];
			Vector3 spawnPoint;
			
			if( useZ )
			{
				spawnPoint = Random.insideUnitSphere;
			}
			else
			{
				spawnPoint = Random.insideUnitCircle;
			}
			
			spawnPoint.Scale(new Vector3(spawnRadius, spawnRadius, spawnRadius));
			spawnPoint += gameObject.transform.position;
			
			
			GameObject newObj = Instantiate(obj,spawnPoint,Quaternion.identity) as GameObject;
			newObj.name = obj.name;
			float expForce = Random.Range(minExplosionForce, maxExplosionForce);
			newObj.rigidbody.AddExplosionForce(expForce, gameObject.transform.position, 0);
		}
		
		Destroy(gameObject);
	}
}
