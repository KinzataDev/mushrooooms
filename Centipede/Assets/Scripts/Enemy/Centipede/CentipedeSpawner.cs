using UnityEngine;
using System.Collections;

public class CentipedeSpawner : MonoBehaviour {
	
	public GameObject pede;
	
	public float width = 1;
	
	public int maxSpawnAttempts = 50;
	
	public float spawnRate = 5;
	public int spawnCount = 1;
	public int spawnTotal = 0;
	private float spawnTimer = 0;
	
	public bool spawning = true;
	
	private Camera mainCamera;
	
	// Use this for initialization
	void Start () {
		mainCamera = Camera.mainCamera;
		
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
		int timestamp = (int) (System.DateTime.UtcNow - epochStart).TotalSeconds;

		Random.seed = timestamp;
	}
	
	// Update is called once per frame
	void Update () {
		if( spawning )
		{
			if( spawnTotal > 0 )
			{
				spawnTimer += Time.deltaTime;
				
				if( spawnTimer >= spawnRate )
				{
					Spawn();
					spawnTimer = 0;
				}	
			}
			else
			{
				spawning = false;
			}
		}
	}
	
	public void Spawn()
	{	
		int attempt = 0;
		while( attempt < maxSpawnAttempts )
		{
			attempt++;
			Ray ray;
			RaycastHit hit;
			
			float x = (Random.value * width) + transform.position.x;
			Vector3 point = new Vector3(x,transform.position.y,0);
			
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
						GameObject newObj = Instantiate(pede, point, Quaternion.identity) as GameObject;
						newObj.name = pede.name;
						
						Debug.Log("Spawned Pede");
						spawnTotal--;
						attempt = maxSpawnAttempts;
					}
				}
			}	
		}
		
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + width,transform.position.y, 0));
	}
	
}
