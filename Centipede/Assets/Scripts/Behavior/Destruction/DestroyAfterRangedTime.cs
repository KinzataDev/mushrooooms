using UnityEngine;
using System.Collections;

public class DestroyAfterRangedTime : MonoBehaviour {
	
	public float minTime = 3f;
	public float maxTime = 6f;
	
	private float timeToDestroy;
	private float curTime = 0;
	
	// Use this for initialization
	void Start () {
		timeToDestroy = Random.Range(minTime, maxTime+1);
	}
	
	// Update is called once per frame
	void Update () {
		curTime += Time.deltaTime;
		
		if( curTime >= timeToDestroy )
		{
			Destroy(gameObject);
		}
	}
}
