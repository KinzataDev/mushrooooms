using UnityEngine;
using System.Collections;

public class SpawnChanceOnDestroy : MonoBehaviour {

	void OnDestroy()
	{
		GameObject spawner = GameObject.Find("PowerUpSpawner");
		GameObject control = GameObject.Find("GameLevelControl");
		if( spawner && control && control.GetComponent<GameLevelControl>().currentState == GameLevelControl.State.Running)
		{
			spawner.GetComponent<PowerUpSpawner>().ChanceToSpawn(gameObject.transform.position);
		}
	}
}
