using UnityEngine;
using System.Collections;

public class LoseLifeOnKill : MonoBehaviour {

	void OnKill()
	{
		PlayerLifeKeeper.PlayerDied();
	}
}
