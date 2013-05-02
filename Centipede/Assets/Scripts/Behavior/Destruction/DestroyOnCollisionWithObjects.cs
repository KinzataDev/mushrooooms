using UnityEngine;
using System.Collections;

public class DestroyOnCollisionWithObjects : MonoBehaviour {
	
	public GameObject[] Objects;
	
	void OnCollisionEnter(Collision hit)
	{
		foreach(GameObject obj in Objects)
		{
			if( hit.gameObject.name == obj.gameObject.name )
			{
				Destroy(gameObject);
			}
		}
	}
}
