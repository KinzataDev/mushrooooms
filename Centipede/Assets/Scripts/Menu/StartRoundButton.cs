using UnityEngine;
using System.Collections;

public class StartRoundButton : MonoBehaviour {
	
	public GUISkin menuSkin;
	public float areaWidth;
	public float areaHeight;
	
	void OnGUI()
	{
		GUI.skin = menuSkin;
		
		float ScreenX = ((Screen.width * 0.875f) - (areaWidth * 0.5f));
		float ScreenY = ((Screen.height * 0.95f) - (areaHeight * 0.5f));
		
		GUILayout.BeginArea( new Rect(ScreenX,ScreenY, areaWidth, areaHeight));
		
		if( GUILayout.Button("Start Round"))
		{
			GameLevelControl control = GameObject.Find("GameLevelControl").GetComponent<GameLevelControl>();
			audio.Play();
			control.BeginLevel();
		}
		
		GUILayout.EndArea();
	}
}
