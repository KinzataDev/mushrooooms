using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {
	
	public GameObject[] powerUps;
	public float spawnChance;
	
	public void ChanceToSpawn(Vector3 position)
	{
		if( Random.value <= spawnChance )
		{
			Spawn(position);
		}
	}
	
	public void Spawn(Vector3 position)
	{
		GameObject obj = powerUps[Random.Range(0, powerUps.Length)];
		GameObject newObj = Instantiate(obj, position, Quaternion.identity) as GameObject;
		newObj.name = obj.name;
	}
}
