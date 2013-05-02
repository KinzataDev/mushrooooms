using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	
	private static long currentScore;
	
	// Use this for initialization
	void Start () {
		ResetScore();
	}
	
	public static void AddScore(int scoreToAdd)
	{
		currentScore += scoreToAdd;
		GameObject textObj = GameObject.Find("ScoreText");
		
		if( textObj != null )
		{
			textObj.SendMessage("UpdateScore");	
		}
	}
	
	public static void LowerScore(int scoreToLower)
	{
		currentScore -= scoreToLower;
		GameObject textObj = GameObject.Find("ScoreText");
		
		if( textObj != null )
		{
			textObj.SendMessage("UpdateScore");	
		}
	}
	
	public static void ResetScore()
	{
		currentScore = 0;
	}
	
	public static long GetScore()
	{
		return currentScore;
	}
}
