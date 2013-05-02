using UnityEngine;
using System.Collections;

public class ScoreObject : MonoBehaviour {
	
	public float fadeTime = 3;
	
	private float currentFadeTime = 0;
	
	// Use this for initialization
	void Start () {
		// Give the material a random color each spawn
		float r = Random.value;
		float g = Random.value;
		float b = Random.value;
		gameObject.renderer.material.color = new Color(r,g,b,1);
		
		Vector3 explosionPos = gameObject.transform.position;
		explosionPos[1] -= 1;
		explosionPos += Random.insideUnitSphere;
		
		gameObject.rigidbody.AddExplosionForce(300.0f, explosionPos, 4);
	}
	
	// Update is called once per frame
	void Update () {
		
		currentFadeTime += Time.deltaTime;
		
		float alphaScale = (fadeTime - currentFadeTime) / fadeTime;
		
		Color color = gameObject.renderer.material.color;
		color.a = alphaScale;
		gameObject.renderer.material.color = color;
	}
}
