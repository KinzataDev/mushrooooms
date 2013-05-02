using UnityEngine;
using System.Collections;

public class AddScoreOnDestroy : MonoBehaviour {
	
	public int scoreWorth = 0;
	
	void OnDestroy()
	{
		if( GameObject.Find("GameLevelControl").GetComponent<GameLevelControl>().currentState == GameLevelControl.State.Running )
		{
			ScoreKeeper.AddScore(scoreWorth);	
		}
	}
}
