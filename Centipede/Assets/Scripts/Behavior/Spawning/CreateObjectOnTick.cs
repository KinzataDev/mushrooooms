using UnityEngine;
using System.Collections;

public class CreateObjectOnTick : MonoBehaviour {
	
	public GameObject obj;
	
	public float timeToSpawn = 1f;
	private float currentTime = 0f;
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		
		if( currentTime >= timeToSpawn )
		{
			Instantiate(obj, transform.position, Quaternion.identity);
			currentTime = 0;
		}
	}
}
