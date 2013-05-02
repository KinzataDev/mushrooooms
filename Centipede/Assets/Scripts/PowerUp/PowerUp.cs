using UnityEngine;
using System.Collections;


public class PowerUp : MonoBehaviour {
	
	public GameObject player;
	public float timeToDespawn;
	
	private float currentTimeLive = 0;
	
	void OnCollisionEnter(Collision hit)
	{
		if( hit.gameObject.name == player.name )
		{
			gameObject.SendMessage("Activate");
		}
		
	}
	
	void Update()
	{
		if( renderer.enabled )
		{
			currentTimeLive += Time.deltaTime;
			if( currentTimeLive >= timeToDespawn )
			{
				Destroy(gameObject);
			}
		}
	}
}
