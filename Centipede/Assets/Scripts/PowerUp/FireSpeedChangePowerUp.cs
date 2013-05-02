using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PowerUp))]
public class FireSpeedChangePowerUp : MonoBehaviour {

	public float activatedTime = 10;
	private Shoot shooter;
	
	public float activationChange;
	
	void Start()
	{
		shooter = GameObject.Find("Shooter").GetComponent<Shoot>();
	}
	
	void Activate()
	{
		shooter.shotTime *= activationChange;
		
		renderer.enabled = false;
		collider.enabled = false;
		
		StartCoroutine(CoolDown());
	}
	
	private IEnumerator CoolDown()
	{
		yield return new WaitForSeconds(activatedTime);
		
		shooter.shotTime /= activationChange;
		
		Destroy(gameObject);
	}
	
}
