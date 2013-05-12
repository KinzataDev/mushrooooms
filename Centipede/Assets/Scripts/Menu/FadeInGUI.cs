using UnityEngine;
using System.Collections;

public class FadeInGUI : MonoBehaviour {
	
	public float fadeInTime = 4;
	private float currentFadeInTime = 0;
	
	// Use this for initialization
	void Start () {
		Color col = GUI.color;
		col.a = 0;
		GUI.color = col;
	}
	
	public void OnGUI()
	{
		if( currentFadeInTime <= fadeInTime )
		{
			currentFadeInTime += Time.deltaTime;
			Color col = GUI.color;
			col.a = currentFadeInTime / fadeInTime;
			GUI.color = col;
		}
	}
}
