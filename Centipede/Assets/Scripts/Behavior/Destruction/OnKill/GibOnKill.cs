using UnityEngine;
using System.Collections;

public class GibOnKill : MonoBehaviour {
	
	public bool gibOffScreen = false;
	
	void OnKill()
	{	
		transform.FindChild("Gibber").GetComponent<Gibber>().Gib();
	}
}
