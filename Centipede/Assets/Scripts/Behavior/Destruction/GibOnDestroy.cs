using UnityEngine;
using System.Collections;

public class GibOnDestroy : MonoBehaviour {
	
	public bool gibOffScreen = false;
	
	void OnDestroy()
	{	
		
		if( !gibOffScreen )
		{
			Vector3 pos = Camera.mainCamera.WorldToViewportPoint(transform.position);
			if( pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1) // can't use invisible check here!!!  Obj is already being destroyed
			{
				Debug.Log("Gibbing player");
				transform.FindChild("Gibber").GetComponent<Gibber>().Gib();
			}
		}
		else
		{
			transform.FindChild("Gibber").GetComponent<Gibber>().Gib();
		}
	}
}
