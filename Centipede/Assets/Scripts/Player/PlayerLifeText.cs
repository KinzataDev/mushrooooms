using UnityEngine;
using System.Collections;

public class PlayerLifeText : MonoBehaviour {

	public bool displayLives = false;
	public static string lives = "";
	
	// Use this for initialization
	void Start () {
		displayLives = true;
	}
	
	// Update is called once per frame
	void Update () {
		if( displayLives )
		{
			guiText.enabled = true;
			guiText.text = "Lives: " + lives;
		}
		else
		{
			guiText.enabled = false;	
		}
		
	}
	
	public static void UpdateLives(int numLives)
	{
		lives = numLives.ToString();
	}
}
