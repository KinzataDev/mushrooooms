using UnityEngine;
using System.Collections;

public class AddScoreOnKill : MonoBehaviour {
	
	public int scoreWorth = 0;
	
	void OnKill()
	{
		if( GameObject.Find("GameLevelControl").GetComponent<GameLevelControl>().currentState == GameLevelControl.State.Running )
		{
			ScoreKeeper.AddScore(scoreWorth);	
		}
	}
}
