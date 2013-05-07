using UnityEngine;
using System.Collections;

public class CentipedeMovement : MonoBehaviour {
	
	public float speed = 5;
	private float verticalChange = 1.2f;
	
	public int lossOfPoints;
	public int numPedesToSpawn;
	
	private int movementDirection = 1;
	private bool isMovingDown = false;
	private float oldY;
	
	// Use this for initialization
	void Start () {
		gameObject.rigidbody.velocity = new Vector3(speed,0,0);
		oldY = transform.position.y;
		
		verticalChange = gameObject.transform.FindChild("BigCollider").collider.bounds.extents.y * 2;
	}
	
	// Update is called once per frame
	void Update () {
		if(isMovingDown)
		{
			moveDown();
			float currentY = transform.position.y;
			if( currentY < oldY - verticalChange )
			{
				beginMovingSideways();
			}
		}
		else
		{
			moveSideways();
		}
	}
	
	void OnCollisionEnter(Collision hit)
	{
		if(hit.gameObject.transform.root.gameObject.name == "Background")
		{
			beginMovingDown();
		}
		if(hit.gameObject.name == "Mushroom")
		{
			// Attempt to eat mushroom
			
			
			// If that fails... move down
			beginMovingDown();
		}
		if( hit.gameObject.name == "BottomBorder")
		{
			GameObject spawner = GameObject.Find("CentipedeSpawner");
			if( spawner )
			{
				for( int i = 0; i < numPedesToSpawn; i++)
				{
					spawner.GetComponent<CentipedeSpawner>().Spawn();
				}
			}
			
//			CreateObjectOnDestroy destroyScript = gameObject.GetComponent<CreateObjectOnDestroy>();
//			destroyScript.isEnabled = false;
			
			ScoreObjectSpawner scoreScript = gameObject.GetComponent<ScoreObjectSpawner>();
			scoreScript.scoreOnKill = -lossOfPoints;
			
			Destroy(gameObject);
		}
	}
	
	void moveDown()
	{
		gameObject.rigidbody.velocity = new Vector3(0,-speed,0);
	}
	
	void moveSideways()
	{
		isMovingDown = false;
		if( movementDirection == 1 )
		{
			gameObject.rigidbody.velocity = new Vector3(speed,0,0);	
		}
		else
		{
			gameObject.rigidbody.velocity = new Vector3(-speed,0,0);	
		}
	}
	
	void flipSideways()
	{
		if( movementDirection == 1 )
		{
			movementDirection = 0;	
		}
		else
		{
			movementDirection = 1;
		}
	}
	
	void beginMovingDown()
	{
		oldY = transform.position.y;
		isMovingDown = true;
		gameObject.transform.FindChild("SmallCollider").collider.enabled = false;
	}
	
	void beginMovingSideways()
	{
		// Randomize Direction
		
		flipSideways();
		isMovingDown = false;
		gameObject.transform.FindChild("SmallCollider").collider.enabled = true;
	}
}
