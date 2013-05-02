using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {
	
	public bool displayScore = false;
	public string score = "";
	
	// Use this for initialization
	void Start () {
		displayScore = true;
		score = ScoreKeeper.GetScore().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if( displayScore )
		{
			guiText.enabled = true;
			guiText.text = "Score: " + score;
		}
		else
		{
			guiText.enabled = false;	
		}
		
	}
	
	void UpdateScore()
	{
		score = ScoreKeeper.GetScore().ToString();
	}
}
