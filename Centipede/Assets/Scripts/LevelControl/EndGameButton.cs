using UnityEngine;
using System.Collections;

public class EndGameButton : MonoBehaviour {
	
	public GUISkin menuSkin;
	public float areaWidth;
	public float areaHeight;
	
	void OnGUI()
	{
		GUI.skin = menuSkin;
		
		float ScreenX = ((Screen.width * .3f)) ;//- (areaWidth * 0.5f));
		float ScreenY = ((Screen.height * 0.65f) - (areaHeight * 0.5f));
		
		GUILayout.BeginArea( new Rect(ScreenX,ScreenY, areaWidth, areaHeight));
		
		if( GUILayout.Button("End Game"))
		{
			CleanUpGame();
			Application.LoadLevel("HighScoreScene");
		}
		
		GUILayout.EndArea();
	}
	
	void CleanUpGame()
	{
		GameObject.Find("GameLevelControl").GetComponent<GameLevelControl>().EndLevel(false);
		
		
		int endScore = (int)ScoreKeeper.GetScore();
		GameObject.Find("HighScoreControl").GetComponent<HighScoreControl>().EnterHighScore(endScore);
	}
}
