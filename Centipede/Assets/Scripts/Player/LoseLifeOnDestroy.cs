using UnityEngine;
using System.Collections;

public class LoseLifeOnDestroy : MonoBehaviour {

	void OnDestroy()
	{
		PlayerLifeKeeper.PlayerDied();
	}
}
