using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public GUISkin menuSkin;
	public float areaWidth;
	public float areaHeight;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.skin = menuSkin;
		
		float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
		float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
		
		GUILayout.BeginArea( new Rect(ScreenX,ScreenY, areaWidth, areaHeight));
		
		if( GUILayout.Button("Play"))
		{
			OpenLevel("GameScene");
		}
		GUILayout.Label("");
		if( GUILayout.Button("High Scores"))
		{
			OpenLevel("HighScoreScene");
		}
		GUILayout.Label("");
		if( GUILayout.Button("Quit"))
		{
			Application.Quit();
		}
		
		GUILayout.EndArea();
	}
	
	void OpenLevel(string levelName)
	{
		Application.LoadLevel(levelName);
	}
}
