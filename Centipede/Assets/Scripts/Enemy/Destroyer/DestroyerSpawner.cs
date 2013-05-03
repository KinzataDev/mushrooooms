using UnityEngine;
using System.Collections;

public class DestroyerSpawner : MonoBehaviour {
	
	public GameObject Destroyer;
	
	public float areaHeight = 5;
	
	public float timeToAttemptSpawn = 5f;
	private float currentAttemptTime = 0;
	
	public float spawnChance = 0.1f;
	
	public bool spawning = false;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if( spawning )
		{
			currentAttemptTime += Time.deltaTime;
			
			if( currentAttemptTime >= timeToAttemptSpawn )
			{
				currentAttemptTime = 0;
				AttemptSpawn();
			}	
		}
	}
	
	private void Spawn()
	{
		float y = Random.Range(0f, 6f);
		Vector3 newPosition = gameObject.transform.position;
		newPosition.y += y;
		
		GameObject obj = Instantiate(Destroyer, newPosition, Quaternion.identity) as GameObject;
		obj.name = Destroyer.name;
	}
	
	private void AttemptSpawn()
	{
		if( Random.value <= spawnChance )
		{
			Spawn();
			Debug.Log("Destroyer Spawned");
		}
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, new Vector3(transform.position.x,transform.position.y + areaHeight, 0));
	}
}
