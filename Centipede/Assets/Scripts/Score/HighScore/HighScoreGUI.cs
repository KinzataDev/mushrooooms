using UnityEngine;
using System.Collections;

public class HighScoreGUI : MonoBehaviour {
	
	public int numHighScores = 10;
	
	public GUISkin menuSkin;
	public float areaWidth;
	public float areaHeight;

	
	 private string highScoreString = "highscorepos";
	
	void Start()
	{
		
	}
	
	void OnGUI()
	{
		GUI.skin = menuSkin;
		
		float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
		float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
		
		GUILayout.BeginArea( new Rect(ScreenX,ScreenY, areaWidth, areaHeight));
		
		
		for( int i = 1; i <= numHighScores; i++ )
		{
			GUILayout.Box("Position " +i+ ":" + PlayerPrefs.GetInt(highScoreString+i), menuSkin.GetStyle("Box"));
		}
		

		
		if( GUILayout.Button("Back"))
		{
			Application.LoadLevel("MainMenuScene");
		}
		
		GUILayout.EndArea();
	}
}
