using UnityEngine;
using System.Collections;

public class HighScoreGUI : MonoBehaviour {
	
	public int numHighScores = 10;
	
	public GUISkin menuSkin;
	public float areaWidth;
	public float areaHeight;
	
	private bool dataRetrieved = false;
	
	private ScoreData[] data;
	private StatData statData;
	
	// private string highScoreString = "highscorepos";
	
	void Start()
	{
		
	}
	
	void OnGUI()
	{
		
		if( !dataRetrieved )
		{
			WWWScore scoreRequest = GameObject.Find("WWWScore").GetComponent<WWWScore>();
			data = scoreRequest.getTopTenHighScores();
			statData = scoreRequest.getTotalStats();
			dataRetrieved = true;
		}
		
		GUI.skin = menuSkin;
		
		float ScreenX = ((Screen.width * 0.5f) - (areaWidth * 0.5f));
		float ScreenY = ((Screen.height * 0.5f) - (areaHeight * 0.5f));
		
		GUILayout.BeginArea( new Rect(ScreenX,ScreenY, areaWidth, areaHeight));
		
		
//		
		for( int i = 0; i < data.Length; i++ )
		{
			GUILayout.Box("Position " +(i+1)+ ":" + data[i].Name +" : "+ data[i].Score);
		}
		
//		for( int i = 1; i <= numHighScores; i++ )
//		{
//			GUILayout.Box("Position " +i+ ":" + PlayerPrefs.GetInt(highScoreString+i), menuSkin.GetStyle("Box"));
//		}
		
		GUILayout.Label(" ");
		
		
		
		GUILayout.Box("Games: " + statData.games + "  Bullets Fired: " + statData.mushrooms + "  Mushrooms Squashed: " + statData.bullets + "  Pedes Killed: " + statData.pedes);
		
		GUILayout.Label(" ");
		
		if( GUILayout.Button("Back"))
		{
			Application.LoadLevel("MainMenuScene");
		}
		
		GUILayout.EndArea();
	}
}
