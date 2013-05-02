using UnityEngine;
using System.Collections;

public class PlayerLifeKeeper : MonoBehaviour {
	
	private static int numLives = 0;
	
	void Start()
	{
		Reset();
	}
	
	public static void PlayerDied()
	{	
		GameLevelControl control = GameObject.Find("GameLevelControl").GetComponent<GameLevelControl>();
		
		if( numLives > 0 )
		{
			control.ResetLevel();
			numLives--;
			PlayerLifeText.UpdateLives(numLives);
		}
		else
		{
			control.GameOver();
		}
	}
	
	public static void AddLife()
	{
		numLives++;
		PlayerLifeText.UpdateLives(numLives);
	}
	
	public static void Reset()
	{
		numLives = 3;
		PlayerLifeText.UpdateLives(numLives);
	}
	
	public static int CountLives()
	{
		return numLives;
	}
}
