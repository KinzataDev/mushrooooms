using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour {

	public GameObject player;
	
	public void SpawnPlayer()
	{
		if( GameObject.Find("Player") == null)
		{
			GameObject obj = Instantiate(player, gameObject.transform.position, Quaternion.identity) as GameObject;
			obj.name = player.name;	
		}
	}
}
