using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PowerUp))]
public class PlayerLifePowerUp : MonoBehaviour {

	void Activate()
	{
		PlayerLifeKeeper.AddLife();
		Destroy(gameObject);
	}
}
