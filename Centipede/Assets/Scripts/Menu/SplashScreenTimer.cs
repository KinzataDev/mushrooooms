using UnityEngine;
using System.Collections;

public class SplashScreenTimer : MonoBehaviour {
	
	public float timeToHold = 2f;
	private float time = 0f;
	
	private bool hasFired = false;
	
	public string sceneToLoad;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		
		if( !hasFired )
		{
			if( time >= timeToHold )
			{
				GameObject.Find("AlphaMap").GetComponent<FadeOutScene>().FadeOut(sceneToLoad);
				hasFired = true;
			}	
		}
		
	}
}
