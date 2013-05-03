using UnityEngine;
using System.Collections;

public class MushroomSpawner : MonoBehaviour {
	
	public GameObject shroom;
	
	public float width = 1;
	public float height = 1;
	
	public int maxSpawnAttempts = 5;
	
	public float spawnRate = 5;
	public int spawnCount = 1;
	private float spawnTimer = 0;
	
	public bool spawning = true;
	
	private Camera mainCamera;
	
	// Use this for initialization
	void Start () {
		mainCamera = Camera.mainCamera;
		
	}
	
	// Update is called once per frame
	void Update () {
		if( spawning )
		{
			spawnTimer += Time.deltaTime;
			
			if( spawnTimer >= spawnRate )
			{
				Spawn(spawnCount);
				spawnTimer = 0;
			}
		}
	}
	
	void Spawn(int count)
	{	
		for(int i = 0; i < count; i++)
		{
			int attempt = 0;
			while( attempt < maxSpawnAttempts )
			{
				attempt++;
				Ray ray;
				RaycastHit hit;
				
				float x = (Random.value * width) + transform.position.x;
				float y = (Random.value * height) + transform.position.y;
				Vector3 point = new Vector3(x,y,0);
				
				//Set up our ray from screen to scene
				Vector3 screenPoint = mainCamera.WorldToScreenPoint(point);
				ray = mainCamera.ScreenPointToRay(screenPoint);
				
				//If we hit...
				if(Physics.Raycast (ray, out hit, Mathf.Infinity))
				{
					if( hit.collider.gameObject.name == "Background")
					{
						GameObject tempObj = GameObject.Find("Mushroom");
						float radius;
						
						if( tempObj )
						{
							radius = tempObj.collider.bounds.extents.x;
						}
						else{
							radius = 0;
						}
						
						if(!Physics.CheckSphere(point, radius) )//hits.Length == 0 )
						{
							GameObject newObj = Instantiate(shroom, point, Quaternion.identity) as GameObject;
							newObj.name = shroom.name;
							attempt = maxSpawnAttempts;
						}
					}
				}	
			}
		}
	}
	
	void OnDrawGizmos()
	{
		Vector3 position = transform.position;
		position[0] += width * 0.5f;
		position[1] += height * 0.5f;
		position[2] = 2;
		Gizmos.DrawWireCube(position, new Vector3(width,height, 1));
	}
	
}
