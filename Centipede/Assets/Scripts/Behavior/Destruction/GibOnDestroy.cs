using UnityEngine;
using System.Collections;

public class GibOnDestroy : MonoBehaviour {
	
	public bool gibOffScreen = false;
	
	void OnDestroy()
	{	
		Debug.Log("Gibbing player");
		if( !gibOffScreen )
		{
			if( true ) // can't use invisible check here!!!  Obj is already being destroyed
			{
				gameObject.GetComponentInChildren<Gibber>().Gib();
			}
		}
		else
		{
			gameObject.GetComponentInChildren<Gibber>().Gib();
		}
	}
}
