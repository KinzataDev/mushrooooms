using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	void OnCollisionEnter(Collision hit)
	{
		if( hit.gameObject.name == "Mushroom")
		{
			hit.gameObject.SendMessage("OnKill");
		}
		
	}
}
