using UnityEngine;
using System.Collections;

public class OnCreateMushroom : MonoBehaviour {

	void Start () {
		
		// Give the material a random color each spawn
		float r = Random.value;
		float g = Random.value;
		float b = Random.value;
		gameObject.renderer.material.color = new Color(r,g,b,1);
		
		float y = Random.Range(0, 360);
		transform.RotateAroundLocal(new Vector3(0,1,0), y);
		transform.RotateAround(new Vector3(1,0,0), 125);
		
	}
}
