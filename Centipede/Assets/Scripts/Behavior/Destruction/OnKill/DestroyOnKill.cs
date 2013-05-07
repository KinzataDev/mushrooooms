using UnityEngine;
using System.Collections;

public class DestroyOnKill : MonoBehaviour {

	void OnKill()
	{
		Destroy(gameObject);
	}
}
