using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int health = 1;
	public bool canLoseHealth = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void TakeDamage(int amount)
	{
		if( canLoseHealth )
		{
			health -= amount;
			if( health <= 0 )
			{
				gameObject.SendMessage("OnKill");
			}
		}
	}
}
