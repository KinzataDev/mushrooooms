using UnityEngine;
using System.Collections;

public class ScoreObjectSpawner : MonoBehaviour {
	
	public GameObject[] triggers;
	public GameObject scoreObject;
	
	public int scoreOnHit = 0;
	public int scoreOnKill = 0;
	
	void OnCollisionEnter(Collision hit)
	{
		if( scoreOnHit != 0 )
		{
			foreach( GameObject trigger in triggers )
			{
				if( hit.collider.gameObject.name == trigger.name )
				{
					if( GameObject.Find("GameLevelControl").GetComponent<GameLevelControl>().currentState == GameLevelControl.State.Running )
					{
						ScoreKeeper.AddScore(scoreOnHit);	
						GameObject obj = Instantiate(scoreObject, gameObject.transform.position, Quaternion.identity) as GameObject;
						obj.GetComponent<TextMesh>().text = scoreOnHit.ToString();
					}
				}
			}	
		}
	}
	
	void OnKill()
	{
		if( scoreOnKill != 0 )
		{
			GameObject parentObj = GameObject.Find("GameLevelControl");
			if( parentObj && parentObj.GetComponent<GameLevelControl>().currentState == GameLevelControl.State.Running )
			{
				ScoreKeeper.AddScore(scoreOnKill);	
				GameObject obj = Instantiate(scoreObject, gameObject.transform.position, Quaternion.identity) as GameObject;
				obj.GetComponent<TextMesh>().text = scoreOnKill.ToString();
			}	
		}
	}
	
}
