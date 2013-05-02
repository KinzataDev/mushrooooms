using UnityEngine;
using System.Collections;

[RequireComponent( typeof(GUITexture)) ]
[RequireComponent( typeof(EndGameButton)) ]
public class PauseTime : MonoBehaviour {
	
	private bool isPaused = false;
	
	// Use this for initialization
	void Start () {
		isPaused = false;
		guiTexture.enabled = false;
		gameObject.GetComponent<EndGameButton>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyUp(KeyCode.Escape) )
		{
			if( !isPaused )
			{
				PauseGame();
			}
			else
			{
				UnPauseGame();
			}
		}
	}
	
	void PauseGame()
	{
		isPaused = true;
		guiTexture.enabled = true;
		Time.timeScale = 0;	
		gameObject.GetComponent<EndGameButton>().enabled = true;
		
		GameObject player = GameObject.Find("Player");
		if( player )
		{
			Shoot playerGun = player.transform.FindChild("Shooter").GetComponent<Shoot>();
			playerGun.gunEnabled = false;
		}
	}
	
	void UnPauseGame()
	{
		isPaused = false;
		guiTexture.enabled = false;
		Time.timeScale = 1.0f;
		gameObject.GetComponent<EndGameButton>().enabled = false;
		
		if( GameObject.Find("GameLevelControl").GetComponent<GameLevelControl>().isGameRunning() )
		{
			Shoot playerGun = GameObject.Find("Player").transform.FindChild("Shooter").GetComponent<Shoot>();
			playerGun.gunEnabled = true;
		}
	}
	
}
