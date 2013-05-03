using UnityEngine;
using System.Collections;

public class CreateObjectOnBulletHit : MonoBehaviour {
	
	public GameObject CreatedObject;
	
	void OnCollisionEnter(Collision hit)
	{
		Debug.Log("hit");
		if( hit.gameObject.name == "Bullet" )
		{
			GameObject newObj = Instantiate(CreatedObject, transform.position, Quaternion.identity) as GameObject;
			newObj.name = CreatedObject.name;
		}
	}
}
