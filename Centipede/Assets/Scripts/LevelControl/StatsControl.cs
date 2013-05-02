using UnityEngine;
using System.Collections;

public class StatsControl : MonoBehaviour {
	
	public static string playerName = "Enter Name...";
	public static int bullets = 0;
	public static int mushrooms = 0;
	public static int pedes = 0;
	
	public static bool hasEnteredName = false;
	
	public static void Reset()
	{
		bullets = 0;
		mushrooms = 0;
		pedes = 0;
		playerName = "Enter Name...";
		hasEnteredName = false;
	}
	
	void OnGUI()
	{
		if( !hasEnteredName )
		{
			float ScreenX = (Screen.width * .4f) - 100;//- (areaWidth * 0.5f));
			float ScreenY = (Screen.height * 0.5f);
			
			GUILayout.BeginArea( new Rect(ScreenX,ScreenY, 200, 100));
			
			StatsControl.playerName = GUILayout.TextField(StatsControl.playerName);
			
			GUILayout.EndArea();	
		}
	}
}
