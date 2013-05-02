using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PowerUp))]
public class SplitShotPowerUp : MonoBehaviour {

	public float activatedTime = 60;
	private Shoot shooter;
	
	void Start()
	{
		shooter = GameObject.Find("Shooter").GetComponent<Shoot>();
	}
	
	void Activate()
	{
		shooter.AddBullet();
		
		renderer.enabled = false;
		collider.enabled = false;
		
		StartCoroutine(CoolDown());
	}
	
	private IEnumerator CoolDown()
	{
		yield return new WaitForSeconds(activatedTime);
		
		shooter.RemoveBullet();
		
		Destroy(gameObject);
	}
	
}
