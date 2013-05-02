using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PowerUp))]
public class PlayerSpeedChangePowerUp : MonoBehaviour {

	public float activatedTime = 10;
	private MouseMovement movement;
	
	public float activationChange;
	
	void Start()
	{
		movement = GameObject.Find("Player").GetComponent<MouseMovement>();
	}
	
	void Activate()
	{
		movement.speed /= activationChange;
		
		renderer.enabled = false;
		collider.enabled = false;
		
		StartCoroutine(CoolDown());
	}
	
	private IEnumerator CoolDown()
	{
		yield return new WaitForSeconds(activatedTime);
		
		movement.speed *= activationChange;
		
		Destroy(gameObject);
	}
	
}
