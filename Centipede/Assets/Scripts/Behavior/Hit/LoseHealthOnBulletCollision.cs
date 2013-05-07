using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class LoseHealthOnBulletCollision : MonoBehaviour {
	
	public int bulletDamage = 1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision hit)
	{
		if( hit.gameObject.name == "Bullet" )
		{
			Debug.Log("hit");
			gameObject.SendMessage("TakeDamage", bulletDamage);
		}
	}
}
