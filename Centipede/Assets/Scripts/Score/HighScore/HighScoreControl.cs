using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HighScoreGUI))]
public class HighScoreControl : MonoBehaviour {
	
	public int numHighScores = 10;
	
	private int tempScore;
//	private string highScoreString = "highscorepos";
	
	public HighScoreGUI gui;
	
	void Start()
	{
		if( Application.loadedLevelName == "HighScoreScene")
		{
			gui.enabled = true;
		}
		else
		{
			gui.enabled = false;	
		}
	}
	
	public void EnterHighScore(string playerName, int newScore, int bullets, int mushrooms, int pedes)
	{
		WWWScore scoreRequest = GameObject.Find("WWWScore").GetComponent<WWWScore>();
		scoreRequest.postHighScore(playerName, newScore, bullets, mushrooms, pedes);
		
//		// Check high score
//		for( int i = 1; i <= numHighScores; i++ )
//		{
//			if( PlayerPrefs.GetInt(highScoreString+i) < newScore )
//			{
//				tempScore = PlayerPrefs.GetInt(highScoreString+i);
//				PlayerPrefs.SetInt(highScoreString+i, newScore);
//				newScore = tempScore;
//			}
//		}
	}
	
	public void SetGuiOn(bool isOn)
	{
		if( isOn )
		{
			gui.enabled = true;
		}
		else
		{
			gui.enabled = false;
		}
	}
	
	
	
}
